using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Model;
using MVP.View;

public class GamePlayView : BaseMVP<GamePlayPresenter>
{

    [SerializeField]
    private GameObject cut;
    [SerializeField]
    private float cutDestroyTime;

    public override void BindData()
    {
    }

    public override void BindModel(IDataModel data)
    {
    }

    protected override void Init()
    {
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            presenter.Dragging = true;
            presenter.SwipeStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) && presenter.Dragging)
        {
            this.createCut();
        }
    }

    private void createCut()
    {
        presenter.Dragging = false;
        Vector2 swipeEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject cut = Instantiate(this.cut, presenter.SwipeStart, Quaternion.identity) as GameObject;
        cut.GetComponent<LineRenderer>().SetPosition(0, presenter.SwipeStart);
        cut.GetComponent<LineRenderer>().SetPosition(1, swipeEnd);
        Vector2[] colliderPoints = new Vector2[2];
        colliderPoints[0] = new Vector2(0.0f, 0.0f);
        colliderPoints[1] = swipeEnd - presenter.SwipeStart;
        cut.GetComponent<EdgeCollider2D>().points = colliderPoints;
        Destroy(cut.gameObject, this.cutDestroyTime);
    }
}