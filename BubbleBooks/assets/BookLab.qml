// Default empty project template
import bb.cascades 1.0
//import "kits.js" as JSKits

// creates one page with a label
Page {
    Container {
        layout: StackLayout {
            orientation: LayoutOrientation.TopToBottom
        }
        Container{
            background: Color.Cyan
            ListView {
                id: listViewCategory
                rootIndexPath: [0]
                dataModel: XmlDataModel { source: "Headers.xml" }
              //  scrollIndicatorMode: ScrollIndicatorMode.None
                layout: StackListLayout {
                    orientation: LayoutOrientation.LeftToRight
                }
                listItemComponents: [
                    ListItemComponent {
                        type: "categoryNames"
                        Container {
                            layout: StackLayout {
                                orientation: LayoutOrientation.LeftToRight
                            }
                            id: category
                            //        preferredWidth: 100
                            background: Color.Blue
                            Label { 
                                text: ListItemData.name 
                            }
                            Container {
                                maxHeight:300
                                maxWidth:10
                                preferredHeight:50
                                preferredWidth:10
                                horizontalAlignment: HorizontalAlignment.Fill
                                background: Color.create(0.9, 0.9, 0.9, 1.0)
                            }
                        }
                    }
                ]
                onTriggered: {
                    var chosenItem = dataModel.data(indexPath)
                    categoryLabel.text = chosenItem.name
                    listViewSubCategory.rootIndexPath = [indexPath[1]];
                    console.log("indexPath =", indexPath[1]) 
                }
            }
          
        }
        WebView {
            id: webView
            verticalAlignment: verticalAlignment.Center
            preferredHeight: 700
            url: "http://3f2c5e3ddfeb439bab9a2d1093ecdff4.cloudapp.net/"
        }
        Container {
            background: Color.Green
            Label { 
                id: categoryLabel
                text: "Ganres"
            }
            ListView {
                id: listViewSubCategory
                rootIndexPath: [0]
                dataModel: XmlDataModel { source: "Categories.xml" }
                listItemComponents: [
                    ListItemComponent {
                        type: "categoryNames"
                        Container {
                            id: subCategory
                            background: Color.Yellow
                            Label { 
                                text: ListItemData.name 
                            }
                            Divider{
                            }
                        }
                    }
                ]
            }
        }
        Button {
            id: refreshButton
            imageSource: "icon.png"
            text: "Refresh"
            onClicked:{
                webView.url = "http://3f2c5e3ddfeb439bab9a2d1093ecdff4.cloudapp.net/";
            }
        }
        Button {
            id: bubbleButton
            imageSource: "icon.png"
            text: "Open Details"
            onClicked:{
                var bookPage = bookPageDefinition.createObject();
               // bookPage.bindData();
                bookNav.push(bookPage);
            
            }
        }
    }
    attachedObjects : [
        ComponentDefinition {
            id: bookPageDefinition
            source: "asset:///Book.qml"
        }
    ]
}

