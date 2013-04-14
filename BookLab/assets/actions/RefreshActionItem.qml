import bb.cascades 1.0

ActionItem {
    title:"Refresh"
    imageSource: "asset:///images/refresh_icon1.png"
    ActionBar.placement: ActionBarPlacement.OnBar
    onTriggered: {
        webView.url = "http://3f2c5e3ddfeb439bab9a2d1093ecdff4.cloudapp.net/";
    }
}
