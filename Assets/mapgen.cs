using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapgen : MonoBehaviour
{
  // Start is called before the first frame update
  List<int> x = new List<int>();
  int[,] z = new int[10, 10];
  gtile[,] tileList = new gtile[10,10];
  GameObject[,] mList = new GameObject[10, 10];
  GameObject ack;
  gtile[,] pMTile = new gtile[10, 10];

  void Start()
  {
    ack = gameObject;
    for (int i = 0; i < 20; i++) { x.Add(1); }

    for (int i = 0; i < 10; i++)
    {
      for (int q = 0; q < 10; q++)
      {

        z[i, q] = binack();
        if (i > 5 || q > 5)
        {
          x.Add(0);
        }

      }
    }


    for (int i = 0; i < 9; i++)
    {
      int t = 1;

      for (int q = 0; q < 9; q++)
      {
        if (z[i, q] == 1)
        {
          if (i == 0)
          {
            if (q == 0)
            {
              if (z[i, q + 1] == 0)
              {
                z[i, q] = 0;
                //print("1zucked" + i + q);
              }
            }
            else if (q == 10)
            {
              if (z[i, q - 1] == 0)
              {
                z[i, q] = 0;
                //print("2zucked" + i + q);

              }

            }
            else
            {
              if (z[i, q - 1] == 0 && z[i, q + 1] == 0)
              {
                z[i, q] = 0;
                //print("3zucked" + i + q);

              }
            }
          }
          else if (i > 0 && i < 10)
          {
            if (q == 0)
            {
              if (z[i, q + 1] == 0 && z[i - 1, q] == 0)
              {
                z[i, q] = 0;
                //print("4zucked" + i + q);

              }
            }
            else if (q == 10)
            {
              if (z[i, q - 1] == 0 && z[i - 1, q] == 0)
              {
                z[i, q] = 0;
                //print("5zucked" + i + q);

              }
            }
            else
            {
              if (z[i, q - 1] == 0 && z[i, q + 1] == 0 && z[i - 1, q] == 0)
              {
                z[i, q] = 0;
                //print("6zucked" + i + q);

              }
            }

          }


        }


      }
      for (int q = 0; q < 9; q++)
      {
        if (z[i, q] == 1)
        {
          t = 0;
          break;

        }

      }
      if (t == 1)
      {
        for (i = i + 1; i < 10; i++)
        {
          for (int q = 0; q < 10; q++)
          {
            z[i, q] = 0;
          }
        }
      }




    }
    int rowLength = z.GetLength(0);
    int colLength = z.GetLength(1);
    string arrayString = "";
    for (int i = 0; i < rowLength; i++)
    {
      for (int j = 0; j < colLength; j++)
      {
        arrayString += string.Format("{0} ", z[i, j]);
      }
      Debug.Log(arrayString);
      arrayString = "";
    }
    int ct = 0;
    for (int i = 0; i < rowLength; i++)
    {
      for (int j = 0; j < colLength; j++)
      {
        ct++;
        Vector3 k = new Vector3();
        k.x = 20 * j;
        k.y = -17 * i;
        
        if (z[i, j] == 1)
        {
          
          

          
          gtile g = gameObject.AddComponent<gtile>() as gtile;
          g.sGtile(Random.Range(0, 6), k, Random.Range(0, 4),ct,i,j,pMTile);
          pMTile = g.getMTiles();
          tileList[i, j] = g;
          
        }
        else
        { 
          gtile g = gameObject.AddComponent<gtile>() as gtile;
          g.sGtile(k, i, j, pMTile);
          pMTile = g.getMTiles();
          tileList[i, j] = g;
          
        }
        
      }
    }
    print(tileList[0, 0]);
    genMap(tileList);
  }
  int binack()
  {
    int p = Random.Range(0, x.Count);
    return (x[p]);
    
  }
  public void genMap(gtile[,] tileList)
  {
    print("begin map gen");
    int rowLength = z.GetLength(0);
    int colLength = z.GetLength(1);
    int istep = -240;
    int jstep = 0;
    int ct = 0;
    for (int i = 0; i < rowLength; i++)
    {
      for (int j = 0; j < colLength; j++)
      {
        
        if (z[i,j] == 1)
        {
          istep += 50;
          //print(tileList[i, j]);
          int mtype = tileList[i, j].getMPlace();
          //GameObject q = Instantiate(Resources.Load("gridTemplates/Grid (" + mtype + ")") as GameObject);
          
          //q.name = ("" + ct);
          ct ++;
          //q.transform.SetParent(transform);
          Vector3 r = new Vector3(istep, jstep);

          //print(i + " " + j);
        }


      }
      istep = -240;
      jstep -= 50;

    }
  }
  // Update is called once per frame
  void Update()
    {
        
    }
  public void cfg()
  {
    int M = 10, N = 10;

    int[,] grid = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

    //print("Original Generation");
    for (int i = 0; i < M; i++)
    {
      for (int j = 0; j < N; j++)
      {
        if (grid[i, j] == 0)
        {
          print(".");
        }
        else
        {
          //print("*");
        }
      }
     
    }
    
    nextGeneration(grid, M, N);
  }
  static void nextGeneration(int[,] grid,
                             int M, int N)
  {
    int[,] future = new int[M, N];

    for (int l = 1; l < M - 1; l++)
    {
      for (int m = 1; m < N - 1; m++)
      {

        int aliveNeighbours = 0;
        for (int i = -1; i <= 1; i++)
          for (int j = -1; j <= 1; j++)
            aliveNeighbours +=
                    grid[l + i, m + j];


        aliveNeighbours -= grid[l, m];


        if ((grid[l, m] == 1) &&
                    (aliveNeighbours < 2))
          future[l, m] = 0;

        else if ((grid[l, m] == 1) &&
                     (aliveNeighbours > 3))
          future[l, m] = 0;

        else if ((grid[l, m] == 0) &&
                    (aliveNeighbours == 3))
          future[l, m] = 1;

        else
          future[l, m] = grid[l, m];
      }
    }

    //print("Next Generation");
    for (int i = 0; i < M; i++)
    {
      for (int j = 0; j < N; j++)
      {
        if (future[i, j] == 0)
          print(".");
        else
         print("*");
      }
      
    }
  }
}
public class mTile : MonoBehaviour
{

  int type;
  int mplace;
  Vector3 pos;
  GameObject gobj;
  bool ttile = false;
  int ct;
  public int ents;
  int x = 0;
  int y = 300;
  public int rot = 0;

  public bool getTTile()
  {
    return ttile;
  }
  public int getMPlace()
  {
    return mplace;
  }
  public void mGTile(int type, Vector3 pos, int mplace, int ct, int ents, int rot)
  {

    this.type = type;
    this.pos = pos;
    this.mplace = mplace;
    this.ttile = true;
    
    this.ents = ents;
    this.gobj = Instantiate(Resources.Load("Image1" ) as GameObject );
    Texture2D tex = Resources.Load("map/Grid (" + this.ents + ")") as Texture2D;
    Sprite im = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    this.gobj.GetComponent<Image>().sprite = (im);
    this.gobj.transform.SetParent(gameObject.transform);
    this.gobj.transform.position = this.pos + new Vector3(x,y,0); 
    this.gobj.transform.localScale = new Vector3(0.1f, 0.1f, 1);
    this.ct = ct;
    this.rot = rot;
    this.gobj.name = "" + ct;
    

     this.gobj.transform.Rotate(new Vector3(0,0,90*this.rot));
    
  }

}
public class gtile : MonoBehaviour
{
  int type;
  int mplace;
  int ents;
  Vector3 pos;
  GameObject gobj;
  bool ttile = false;
  int ct;
  int curx;
  int cury;
  int rot;
  int dAv;
  int rAv;
  gtile[,] mtiles = new gtile[10, 10];
  public bool getTTile()
  {
    return ttile;
  }
  public int getDAv()
  {
    return dAv;
  }
  public int getRAv()
  {
    return rAv;
  }
  public int getMPlace()
  {
    return mplace;
  }
  public gtile[,] getMTiles()
  {
    return mtiles;
  }

  public void sGtile(int type, Vector3 pos, int mplace, int ct, int curx, int cury, gtile[,] mtiles)
  {

    this.type = type;
    this.pos = pos;
    this.mplace = mplace;
    this.curx = curx;
    this.cury = cury;
    this.ents = Random.Range(1, 4);
    this.ttile = true;
    this.gobj = Instantiate(Resources.Load("gridTemplates/Grid (" + type + ")") as GameObject);
    this.gobj.transform.position = this.pos;
    this.mtiles = mtiles;
    this.ct = ct;
    this.gobj.name = "" +ct;
    
    setsht();

  }
  
  public void sGtile(Vector3 pos, int curx, int cury, gtile[,] mtiles)
  {
    this.mtiles = mtiles;
    this.type = 7;
    this.curx = curx;
    this.cury = cury;
    this.pos = pos;
    this.ents = 0;
    setsht();
  }
  public void setsht()
  {
    print(mtiles[0, 0]);
    gtile ltile;
    gtile utile;
    int[] pEnts = new int[5];
    int[] pRots = new int[5];
    int pLAv;
    int pUAv;
   
    //print("hi");
    if (curx != 0)
    {
      ltile = mtiles[curx - 1, cury];
    }
    else
    {
      ltile = null;
    }

    if (cury != 0)
    {
      utile = mtiles[curx, cury - 1];
    }
    else
    {
      utile = null;
    }

    if(ltile != null)
    {
      pUAv = ltile.getDAv();
    }
    else
    {
      pUAv = 0;
    }
    
    if (ltile != null)
    {
      pLAv = ltile.getRAv();
    }
    else
    {
      pLAv = 0;
    }
    print(pUAv);
    print(pLAv);
    for (int i = 0; i<5; i++)
    {
      pEnts[i] = i;

    }
    for (int i = 0; i < 4; i++)
    {
      pRots[i] = i;

    } 
    print("(" + curx + ", " + cury + "): (" + pLAv + ", " + pUAv + ")");
    if (pLAv ==1 || pUAv == 1)
    {
      pEnts[0] = -1;
    }
    if (pLAv == 0 || pUAv == 0)
    {
      pEnts[1] = -1;
    }
    if((pLAv==1 && pUAv == 1) || (pLAv ==0 && pUAv == 0))
    {
      pEnts[2] = -1;
    }
    if ((pLAv == 1 && pUAv == 1) || (pLAv == 0 && pUAv == 0))
    {
      pEnts[4] = -1;
    }
    while (true)
    {
      int x = Random.Range(0, 4);
      if (pEnts[x] >= 0)
      {
        this.ents = x;
        break;
      }
    }
    if(this.ents == 2)
    {
      if(pLAv == 1)
      {
        pRots[0] = -1;
        pRots[2] = -1;
        pRots[3] = -1;
      }
      else if(pUAv == 1)
      {
        pRots[0] = -1;
        pRots[1] = -1;
        pRots[3] = -1;
      }
      else
      {
        pRots[1] = -1;
        pRots[2] = -1;
        
      }

    }
    if(this.ents == 3)
    {
      if(pLAv == 1 && pUAv == 1)
      {
        pRots[0] = -1;
        pRots[1] = -1;
        pRots[3] = -1;
      }else if(pLAv == 1)
      {
        pRots[0] = -1;
        pRots[2] = -1;
        pRots[3] = -1;
      }
      else if (pUAv == 1)
      {
        pRots[0] = -1;
        pRots[1] = -1;
        pRots[2] = -1;
      }
      else
      {
        
        pRots[1] = -1;
        pRots[2] = -1;
        pRots[3] = -1;
        
      }
    }
    if(this.ents == 4)
    {
      if (pLAv == 1)
      {
        pRots[0] = -1;
        pRots[2] = -1;
        
      }
      else if (pUAv == 1)
      {
        
        pRots[1] = -1;
        pRots[3] = -1;
      }
      

    }

    while (true)
    {
      int x = Random.Range(0, 3);
      if(pRots[x] >= 0)
      {
        this.rot = x;
        break;
      }
    }
    mTile g = gameObject.AddComponent<mTile>() as mTile;


    g.mGTile(this.type, new Vector3(this.pos.x / 2f, this.pos.y / 1.75f, 0), this.mplace, this.ct, this.ents, this.rot);

    avPas();
    mtiles[curx, cury] = this;
  }
  public void avPas()
  {
    if(this.ents == 0)
    {
      dAv = 0;
      rAv = 0;
    }
    if(this.ents == 1)
    {
      dAv = 1;
      rAv = 1;
    }
    if(this.ents == 2)
    {
      if(this.rot == 0)
      {
        dAv = 1;
        rAv = 0;
      }
      if (this.rot == 1 || this.rot == 2)
      {
        dAv = 0;
        rAv = 0;
      }
      if(this.rot == 3)
      {
        dAv = 0;
        rAv = 1;
      }
    }
    if(this.ents == 3)
    {
      if (this.rot == 0)
      {
        dAv = 1;
        rAv = 1;
      }
      if(this.rot == 1)
      {
        dAv = 1;
        rAv = 0;
      }
      if (this.rot == 2)
      {
        dAv = 0;
        rAv = 0;
      }
      if (this.rot == 3)
      {
        dAv = 0;
        rAv = 1;
      }
    }
    if(this.ents == 4)
    {
      if(this.rot == 0 || this.rot == 2)
      {
        dAv = 1;
        rAv = 0;
      }
      if (this.rot == 0 || this.rot == 3)
      {
        dAv = 0;
        rAv = 1;
      }
    }
    print("eee");
    print(rAv);
  }
  public int[] remNum(int[] arr, int num)
  {
    for(int i = 0; i <arr.Length-1; i++)
    {
      if (arr[i] == num)
      {
        arr[i] = 5;
        
      }
    }
    return (arr);
  }
  public override string ToString()
  {
    return ("pos: " + this.pos + System.Environment.NewLine + "type: " + this.type + System.Environment.NewLine + "mplace: " + this.mplace);
    
    
  }
  }

