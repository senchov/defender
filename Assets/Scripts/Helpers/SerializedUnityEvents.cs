using System;
using UnityEngine.Events;
using Assets.Scripts.View;
using UnityEngine;

[Serializable] public class SpawnableUnityEvent : UnityEvent<ISpawnable> { }
[Serializable] public class SpawnNotifierUnityEvent : UnityEvent<ISpawnNotifier> { }
[Serializable] public class CooldownViewUnityEvent : UnityEvent<ICooldownView> { }
[Serializable] public class MovebleViewStringUnityEvent : UnityEvent<IMoveble, string> { }
[Serializable] public class MovebleViewUnityEvent : UnityEvent<IMoveble> { }
[Serializable] public class Vector3UnityEvent : UnityEvent<Vector3> { }
[Serializable] public class DistanceToTargetUnityEvent : UnityEvent<string, ITargetSetter, IDistanceToTargetSetter> { }
[Serializable] public class AtackebleUnityEvent : UnityEvent<IAtackable> { }
[Serializable] public class FortStateReceiverUnityEvent : UnityEvent<IFortStateReceiver> { }


