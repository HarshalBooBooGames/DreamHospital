using UnityEngine;

public class FixMeshCollider : MonoBehaviour
{
    private MeshCollider meshCollider;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Mesh mesh;

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    private void Start()
    {
        mesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(mesh);
        meshCollider.sharedMesh = mesh;
    }
}
