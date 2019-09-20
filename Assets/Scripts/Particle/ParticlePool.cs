using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool getItemParticle;
    public static ParticlePool conflictParticle;

    private LayerMask PARTICLE_LAYER;

    public enum PoolType
    {
        GetItem,
        Conflict
    }

    public PoolType type;

    private delegate void InitPool();

    private InitPool init;

    private void Start()
    {
        PARTICLE_LAYER = LayerMask.NameToLayer("Particle");


        init();

    }

    private void InitGetItemParticlePool()
    {
        
    }

    private void InitConflictParticlePool()
    {
       

    }

    public void CallParticle(int particleID, Vector3 emitPosition)
    {
        ParticleSystem particle = getParticleObject(getParticlePoolByID(particleID));
        particle.transform.position = emitPosition;
        particle.gameObject.SetActive(true);
        particle.Play();
    }


    private GameObject getParticlePoolByID(int particleID)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).name == particleID + "")
            {
                return gameObject.transform.GetChild(i).gameObject;
            }
        }
        Debug.Assert(false, "Wrong Particle ID");
        return null;
    }


    private ParticleSystem getParticleObject(GameObject ID_Tag)
    {
        for (int i = 0; i < ID_Tag.transform.childCount; i++)
        {
            GameObject childObj = ID_Tag.transform.GetChild(i).gameObject;
            ParticleSystem particle = childObj.GetComponent<ParticleSystem>();

            if (particle.IsAlive(true) == false)
            {
                return particle;
            }
        }

        extendList(ID_Tag, 5);
        return getParticleObject(ID_Tag);
    }

    // List 내 생성된 파티클을 늘림
    private void extendList(GameObject ID_Tag, int extendSize)
    {
        int index = ID_Tag.transform.childCount;

        for (int i = index; i < index + extendSize; i++)
        {
            GameObject particleObj = Instantiate(ID_Tag.transform.GetChild(0).gameObject, Vector3.zero, Quaternion.identity);
            particleObj.name = ID_Tag.name + " (" + i + ")";
            particleObj.transform.parent = ID_Tag.transform;
            particleObj.SetActive(false);
            particleObj.layer = PARTICLE_LAYER;
        }

    }

}
