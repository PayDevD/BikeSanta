using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BikeSanta
{
    [Serializable]
    public class Particle
    {
        [SerializeField]
        public int ID;
        [SerializeField]
        public ParticleSystem particle;

        // 기본적으로 생성해놓을 파티클의 갯수
        [NonSerialized]
        public int defaultParticlesNumber = 5;
        [NonSerialized]
        public int currentParticlesNumber = 0;
    }
}