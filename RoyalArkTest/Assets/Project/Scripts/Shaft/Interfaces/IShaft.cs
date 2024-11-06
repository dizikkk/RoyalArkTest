using RoyalArkTest.Resource;
using UnityEngine;

namespace RoyalArkTest.Shaft.Interfaces
{
    public interface IShaft
    {
        public Transform Transform { get; }
        public void Init();
        public IResource GiveResource();
    }
}