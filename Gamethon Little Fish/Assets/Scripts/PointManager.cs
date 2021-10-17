using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
   [SerializeField] int[] coord;
    [SerializeField] Pontos point1;
    [SerializeField] Pontos point2;
    [SerializeField] Pontos point3;
    float P1P2;
    float P2P3;
  //  float P1P3;
    bool draw = false;
    bool draw2 = false;
    public int count = 0;
    GameObject P;
    public List<GameObject> points;

    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        coord = new int[6];
        point1 = new Pontos();
        point2 = new Pontos();
        point3 = new Pontos();
        points = new List<GameObject>();

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.positionCount = 4;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(coord[0] + " " + coord[1] + " " + coord[2] + " " + coord[3] + " " + coord[4] + " " + coord[5]);

        if (draw == true)
        {
            DrawLine();
        }
        if (draw2 == true)
        {
            DrawLine2();
        }
       
        if(Input.GetKeyDown(KeyCode.L))
        {
            PointUpdate();
            DrawLine();
        }
    }
    

    private void OnGUI() //x
    {
        if (GUI.Button(new Rect(Screen.width - Screen.width, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-9"))
        {
            coord[count] = -9;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-8"))
        {
            coord[count] = -8;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 2 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-7"))
        {
            coord[count] = -7;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 3 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-6"))
        {
            coord[count] = -6;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 4 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-5"))
        {
            coord[count] = -5;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 5 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-4"))
        {
            coord[count] = -4;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 6 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-3"))
        {
            coord[count] = -3;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 7 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-2"))
        {
            coord[count] = -2;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 8 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "-1"))
        {
            coord[count] = -1;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 9 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "0"))
        {
            coord[count] = 0;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 10 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "1"))
        {
            coord[count] = 1;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 11 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "2"))
        {
            coord[count] = 2;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 12 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "3"))
        {
            coord[count] = 3;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 13 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "4"))
        {
            coord[count] = 4;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "5"))
        {
            coord[count] = 5;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 15 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "6"))
        {
            coord[count] = 6;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 16 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "7"))
        {
            coord[count] = 7;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 17 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "8"))
        {
            coord[count] = 8;
            PointUpdate();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width + 18 * Screen.width / 19, Screen.height - Screen.height, Screen.width / 19, Screen.height / 19), "9"))
        {
            coord[count] = 9;
            PointUpdate();
        }

        if (GUI.Button(new Rect(Screen.width - Screen.width / 12, Screen.height - Screen.height / 15, Screen.width / 12, Screen.height / 15), "Sair"))
        {
            Application.Quit();
        }
        if (GUI.Button(new Rect(Screen.width - Screen.width / 12 * 2, Screen.height - Screen.height / 15, Screen.width / 12, Screen.height / 15), "Novo Triângulo"))
        {
            SceneManager.LoadScene(0);
        }

        GUI.Label(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height + Screen.height / 19, Screen.width / 15, Screen.height / 5), "P1 = (" + point1.X.ToString() + "," + point1.Y.ToString() +")");
        GUI.Label(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height + 1.5f * Screen.height / 19, Screen.width / 15, Screen.height / 5), "P2 = (" + point2.X.ToString() + "," + point2.Y.ToString() + ")");
        GUI.Label(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height + 2 * Screen.height / 19, Screen.width / 15, Screen.height / 5), "P3 = (" + point3.X.ToString() + "," + point3.Y.ToString() + ")");

        //GUI.Label(new Rect(Screen.width - Screen.width + 15 * Screen.width / 19, Screen.height - Screen.height + Screen.height / 19, Screen.width / 15, Screen.height / 5), "Sin = " + );
        //GUI.Label(new Rect(Screen.width - Screen.width + 15 * Screen.width / 19, Screen.height - Screen.height + 1.5f * Screen.height / 19, Screen.width / 15, Screen.height / 5), "Sin = " + );
        //GUI.Label(new Rect(Screen.width - Screen.width + 15 * Screen.width / 19, Screen.height - Screen.height + 2 * Screen.height / 19, Screen.width / 15, Screen.height / 5), "Sin = " +);

        //GUI.Label(new Rect(Screen.width - Screen.width + 16 * Screen.width / 19, Screen.height - Screen.height + Screen.height / 19, Screen.width / 15, Screen.height / 5), "Cos = ");
        //GUI.Label(new Rect(Screen.width - Screen.width + 16* Screen.width / 19, Screen.height - Screen.height + 1.5f * Screen.height / 19, Screen.width / 15, Screen.height / 5), "Cos = ");
        //GUI.Label(new Rect(Screen.width - Screen.width + 16 * Screen.width / 19, Screen.height - Screen.height + 2 * Screen.height / 19, Screen.width / 15, Screen.height / 5), "Cos = ");

        //GUI.Label(new Rect(Screen.width - Screen.width + 17 * Screen.width / 19, Screen.height - Screen.height + Screen.height / 19, Screen.width / 15, Screen.height / 5), "Tan = ");
        //GUI.Label(new Rect(Screen.width - Screen.width + 17 * Screen.width / 19, Screen.height - Screen.height + 1.5f * Screen.height / 19, Screen.width / 15, Screen.height / 5), "Tan = ");
        //GUI.Label(new Rect(Screen.width - Screen.width + 17 * Screen.width / 19, Screen.height - Screen.height + 2 * Screen.height / 19, Screen.width / 15, Screen.height / 5), "Tan = ");

      /*  if (CalcularDeterminante() != 0)
        {
            if (draw == true)
            {
                GUI.Label(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height + 3 * Screen.height / 19, Screen.width / 10, Screen.height / 5), "Lado P1P2 = " + P1P2);
            }
            if (draw2 == true)
            {
             //   GUI.Label(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height + 3.5f * Screen.height / 19, Screen.width / 10, Screen.height / 5), "Lado P1P3 = " + P1P3);
                GUI.Label(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height + 4 * Screen.height / 19, Screen.width / 10, Screen.height / 5), "Lado P2P3 = " + P2P3);
                GUI.Label(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height + 5 * Screen.height / 19, Screen.width / 10, Screen.height / 5), "Área = " + Mathf.Abs(CalcularDeterminante()));
            }
        }
        else if (CalcularDeterminante() == 0 && draw2 == true)
        {
            GUI.Label(new Rect(Screen.width - Screen.width + 14 * Screen.width / 19, Screen.height - Screen.height + 3 * Screen.height / 19, Screen.width / 10, Screen.height / 5), "Os pontos inseridos não são capazes de formar um triângulo");
        }*/
    }

    private void PointUpdate()
    {
        if (count == 0)
        {
            point1.X = coord[0];
            count++;
        }
        else if (count == 1)
        {
            point1.Y = coord[1];
            CreatePoint(point1.X, point1.Y);
            count++;
        }
        else if (count == 2)
        {
            point2.X = coord[2];
            count++;
        }
        else if (count == 3)
        {
            point2.Y = coord[3];
            CreatePoint(point2.X, point2.Y);
            count++;
            draw = true;
        }
        else if (count == 4)
        {
            point3.X = coord[4];
            count++;
        }
        else if (count == 5)
        {
            point3.Y = coord[5];
            CreatePoint(point3.X, point3.Y);
            count++;
            draw2 = true;
        }
    }

    private void CreatePoint(int x, int y)
    {
        P = new GameObject("Ponto");
        P.transform.SetParent(this.gameObject.transform);
        P.transform.position = new Vector3(x * 0.20525f, y * 0.215f, 0.5f);
        P.gameObject.AddComponent<Point>();
        points.Add(P);
    }

    void DrawLine()
    {
        if (points[0] != null && points[1] != null)
        {
            lineRenderer.SetPosition(0, points[0].transform.position);
            lineRenderer.SetPosition(1, points[1].transform.position);
        }
    }
    void DrawLine2()
    {
        if (points[2] != null)
        {
            lineRenderer.SetPosition(2, points[2].transform.position);
            lineRenderer.SetPosition(3, points[0].transform.position);
            lineRenderer.loop = true;

            P1P2 = Vector2.Distance(new Vector2(point1.X, point1.Y), new Vector2(point2.X, point2.Y));
            P2P3 = Vector2.Distance(new Vector2(point2.X, point2.Y), new Vector2(point3.X, point3.Y));
          //  P1P3 = Vector2.Distance(new Vector2(point3[0], point3[1]), new Vector2(point1[0], point1[1]));
        }
    }
   /* private float CalcularDeterminante() // x
    {
        //float determinante = (-1 * (point3[0] * point2[1] + point3[1] * point1[0] + point2[0] * point1[1]) + (point1[0] * point2[1] + point1[1] * point3[0] + point2[0] * point3[1])) / 2;
        return determinante;
    }*/

}

