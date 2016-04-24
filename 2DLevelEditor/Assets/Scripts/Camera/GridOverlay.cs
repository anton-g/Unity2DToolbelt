using UnityEngine;
 
 public class GridOverlay : MonoBehaviour {
    public bool showMain = true;
    public bool showSub = false;

    public int gridSizeX;
    public int gridSizeY;

    public float smallStep;
    public float largeStep;

    public float startX;
    public float startY;
    public float startZ;

    private Material lineMaterial;

    private Color mainColor = new Color(0f, 0f, 0f, 0.2f);
    private Color subColor = new Color(0f, 0f, 0f, 0.1f);
    public Shader shader;
     
    void CreateLineMaterial() 
    {
        if( !lineMaterial ) {
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
        }
    }
     
    void OnPostRender() 
    {
        CreateLineMaterial();
        // set the current material
        lineMaterial.SetPass( 0 );

        GL.Begin( GL.LINES );
        
        if(showSub)
        {
            GL.Color(subColor);

            for(float j = 0; j <= gridSizeY; j += smallStep)
            {
                //X axis lines
                GL.Vertex3( startX, j + startY, startZ);
                GL.Vertex3( startX + gridSizeX, j + startY, startZ);
            }

            //Y axis lines
            for(float k = 0; k <= gridSizeX; k += smallStep)
            {
                GL.Vertex3( startX + k, startY, startZ);
                GL.Vertex3( startX + k, gridSizeY + startY, startZ);
            }
        }
        
        if(showMain)
        {
            GL.Color(mainColor);

            for(float j = 0; j <= gridSizeY; j += largeStep)
            {
                //X axis lines
                GL.Vertex3( startX, j + startY, startZ);
                GL.Vertex3( startX + gridSizeX, j + startY, startZ);
            }

            for(float k = 0; k <= gridSizeX; k += largeStep)
            {
                GL.Vertex3( startX + k, startY, startZ);
                GL.Vertex3( startX + k, gridSizeY + startY, startZ);
            }
        }
 
 
        GL.End();
    }
}