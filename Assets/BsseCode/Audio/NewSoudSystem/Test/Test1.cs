using Unity.Entities;
using UnityEngine;

namespace BsseCode.Audio.NewSoudSystem.Test
{
    public class SoundOnSpace : MonoBehaviour
    {
        private EntityManager _entityManager;
        private Entity _soundEntity;

        private void Start()
        {
            // Получаем EntityManager для работы с ECS
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            // Создаём ECS-сущность на основе SoundAuthoring
            _soundEntity = gameObject.GetComponent<GameObjectEntity>().Entity;
        }

        private void Update()
        {
            // Проверяем, нажата ли клавиша пробел
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Если звуковая сущность уже существует, добавляем компонент Sound
                if (!_entityManager.HasComponent<Sound>(_soundEntity))
                {
                    _entityManager.AddComponentData(_soundEntity, new Sound
                    {
                        Id = gameObject.GetComponent<SoundAuthoring>().SoundDefinition.Id
                    });
                }

                // Устанавливаем громкость звука (если это необходимо)
                _entityManager.SetComponentData(_soundEntity, new Volume
                {
                    Value = gameObject.GetComponent<SoundAuthoring>().Volume
                });
            }
        }
    }
}