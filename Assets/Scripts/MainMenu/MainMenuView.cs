using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.View;
using UnityEngine.UI;
using MVP.Model;

public class MainMenuView : BaseMVP<MainMenuPresenter>
{

    [SerializeField]
    private Button btnPlay;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start view");
        btnPlay.onClick.AddListener(
            onPlay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void BindData()
    {

    }

    protected override void Init()
    {

    }

    void onPlay()
    {
        Debug.Log("on play");
        presenter.Play();
    }

    public override void BindModel(IDataModel data)
    {
    }
}