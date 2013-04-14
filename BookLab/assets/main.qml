// Default empty project template
import bb.cascades 1.0
import "actions"
// creates one page with a label
Page {
    Container{
        layout: AbsoluteLayout {}
        ScrollView{
            id: scrollView
            scrollViewProperties {
                scrollMode: ScrollMode.Both
                pinchToZoomEnabled: true
            }
            Container {
                layout: DockLayout {}
                WebView {
                    id: bookWebView
                    verticalAlignment: verticalAlignment.Center
                    horizontalAlignment: horizontalAlignment.Center
                    preferredHeight: 700
                    url: "http://3f2c5e3ddfeb439bab9a2d1093ecdff4.cloudapp.net/"
                    
                    onMinContentScaleChanged: {
                        scrollView.scrollViewProperties.minContentScale = minContentScale;
                    }
                    
                    onMaxContentScaleChanged: {
                        scrollView.scrollViewProperties.maxContentScale = maxContentScale;
                    }
                }
            }
        }        
    }
    actions: [
        RefreshActionItem {
            id: refreshActionItem
        }
    ]
}

