using System;
using System.Collections;
using BsseCode.Audio;
using BsseCode.Caracters.Hero;
using BsseCode.Services;
using BsseCode.Services.Coroutines;
using UnityEngine;
using Zenject;

namespace BsseCode.Pools.Pools.BulletPool
{
    public class Bullet : MonoBehaviour, IPoolsElement
    {
        [SerializeField] private float lifetime = 2f;

        private float _speed;
        private Vector2 _direction;
        private MoveService _moveService;
        private ICoroutineService _coroutineService;
        private Coroutine _coroutineLifeRoutine;
        private Coroutine _audioCoroutine;
        private IPoolController _poolController;
        private Player _player;
        private ISoundsExplorer _soundsExplorer;
        private SoundStorage _soundStorage;
        private AudioSource _sourceAudio;
        private SoursSound _audioElement;

        [Inject]
        public void Construct(
            MoveService moveService,
            IPoolController poolController,
            ICoroutineService coroutineService,
            Player player,
            ISoundsExplorer soundsExplorer,
            SoundStorage soundStorage)
        {
            _moveService = moveService ?? throw new ArgumentNullException(nameof(moveService));
            _poolController = poolController ?? throw new ArgumentNullException(nameof(poolController));
            _coroutineService = coroutineService ?? throw new ArgumentNullException(nameof(coroutineService));
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _soundsExplorer = soundsExplorer ?? throw new ArgumentNullException(nameof(soundsExplorer));
            _soundStorage = soundStorage ?? throw new ArgumentNullException(nameof(soundStorage));
        }

        private void OnEnable() => StartLifeRoutine();
        private void OnDisable() => StopLifeRoutine();

        public void SetParameters(float speed, Vector2 direction)
        {
            _speed = speed;
            _direction = direction.normalized;

            SetRotationBasedOnDirection();
            PlayShootSound();
        }

        private void Update() => MoveBullet();

        /// <summary>
        /// Запускает звук стрельбы.
        /// </summary>
        private void PlayShootSound()
        {
            _audioElement = GetAudioElementFromPool();
            if (_audioElement == null) return;

            _sourceAudio = _audioElement.GetComponent<AudioSource>();
            if (_sourceAudio == null)
            {
                Debug.LogError("AudioSource component is missing on the audio element.");
                return;
            }

            _sourceAudio.transform.position = _player.transform.position;
            _soundsExplorer.PlaySoundFrom(_soundStorage.ShootGun, _sourceAudio);

            StartAudioReturnRoutine(_audioElement, _sourceAudio);
        }

        /// <summary>
        /// Получает элемент аудио из пула.
        /// </summary>
        private SoursSound GetAudioElementFromPool()
        {
            var audioElement = _poolController.GetPool<SoursSound>()?.GetElement();
            if (audioElement == null)
            {
                Debug.LogError("Failed to retrieve audio element from the pool.");
            }
            return audioElement;
        }

        /// <summary>
        /// Запускает корутину возврата аудио-элемента в пул.
        /// </summary>
        private void StartAudioReturnRoutine(SoursSound audioElement, AudioSource sourceAudio)
        {
            StopAudioReturnRoutine();

            _audioCoroutine = _coroutineService?.StartCoroutine(AudioReturnRoutine(audioElement, sourceAudio));
        }

        /// <summary>
        /// Останавливает текущую аудио-корутину, если она активна.
        /// </summary>
        private void StopAudioReturnRoutine()
        {
            if (_audioCoroutine != null)
            {
                _coroutineService?.StopCoroutine(_audioCoroutine);
                _audioCoroutine = null;
            }
        }

        /// <summary>
        /// Корутину для возврата аудио-элемента в пул.
        /// </summary>
        private IEnumerator AudioReturnRoutine(SoursSound audioElement, AudioSource sourceAudio)
        {
            yield return new WaitWhile(() => sourceAudio.isPlaying);
            audioElement.Deactivate();
            _audioCoroutine = null;
        }

        /// <summary>
        /// Движение пули.
        /// </summary>
        private void MoveBullet()
        {
            if (_moveService != null)
            {
                transform.position = _moveService.Move(_direction, _speed, transform.position);
            }
        }

        /// <summary>
        /// Устанавливает поворот объекта на основе направления.
        /// </summary>
        private void SetRotationBasedOnDirection()
        {
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        /// <summary>
        /// Запуск корутины времени жизни пули.
        /// </summary>
        private void StartLifeRoutine()
        {
            StopLifeRoutine();
            _coroutineLifeRoutine = _coroutineService?.StartCoroutine(LifeRoutine());
        }

        /// <summary>
        /// Остановка корутины времени жизни пули.
        /// </summary>
        private void StopLifeRoutine()
        {
            if (_coroutineLifeRoutine != null)
            {
                _coroutineService?.StopCoroutine(_coroutineLifeRoutine);
                _coroutineLifeRoutine = null;
            }
        }

        /// <summary>
        /// Корутину времени жизни пули.
        /// </summary>
        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(lifetime);
            Deactivate();
        }

        /// <summary>
        /// Деактивация пули и возврат в пул.
        /// </summary>
        public void Deactivate() => _poolController?.ReturnToPool(this);
    }
}
