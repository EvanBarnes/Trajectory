using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapgen : MonoBehaviour
{
  // Start is called before the first frame update
  List<int> x = new List<int>();
  int[,] z = new int[10, 10];
  gtile[,] tileList;
  void Start()
  {
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
                print("1zucked" + i + q);
              }
            }
            else if (q == 10)
            {
              if (z[i, q - 1] == 0)
              {
                z[i, q] = 0;
                print("2zucked" + i + q);

              }

            }
            else
            {
              if (z[i, q - 1] == 0 && z[i, q + 1] == 0)
              {
                z[i, q] = 0;
                print("3zucked" + i + q);

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
                print("4zucked" + i + q);

              }
            }
            else if (q == 10)
            {
              if (z[i, q - 1] == 0 && z[i - 1, q] == 0)
              {
                z[i, q] = 0;
                print("5zucked" + i + q);

              }
            }
            else
            {
              if (z[i, q - 1] == 0 && z[i, q + 1] == 0 && z[i - 1, q] == 0)
              {
                z[i, q] = 0;
                print("6zucked" + i + q);

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
    for (int i = 0; i < rowLength; i++)
    {
      for (int j = 0; j < colLength; j++)
      {
        Vector3 k = new Vector3();
        k.x = 20 * j;
        k.y = -17 * i;
        gtile g;
        if (z[i, j] == 1)
        {
          
          

          g = new gtile(Random.Range(0, 6), k, Random.Range(0, 14));
          

        }
        else
        {
          g = new gtile(k);
        }
        tileList[i, j] = g;
      }
    }
  }
  int binack()
  {
    int p = Random.Range(0, x.Count);
    return (x[p]);
    
  }
    // Update is called once per frame
    void Update()
    {
        
    }
}
class gtile : MonoBehaviour{
  int type;
  int mplace;
  Vector3 pos;
  GameObject gobj;
  bool ttile;

  public gtile(int type, Vector3 pos, int mplace)
  {
    this.type = type;
    this.pos = pos;
    this.mplace = mplace;
    this.ttile = true;
    this.gobj = Instantiate(Resources.Load("gridTemplates/Grid (" +type + ")") as GameObject);
    this.gobj.transform.position = this.pos;
    
  }
  public gtile(Vector3 pos)
  {
    this.type = 7;
    this.pos = pos;
  }


}

