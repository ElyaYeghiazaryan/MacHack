// Default empty project template
import bb.cascades 1.0

// creates one page with a label
Page {
    property string bookName: "N/A"
    property string bookAuthor: "UNKNOWN"
    property string bookRating: "0"
    property string bookDesctiption: "This book is about..."
    Container {
        layout: StackLayout {
            orientation: LayoutOrientation.TopToBottom
        }
        Container {
            background: Color.DarkCyan
            horizontalAlignment: HorizontalAlignment.Fill
            minHeight: 200
            layout: StackLayout {
                orientation: LayoutOrientation.LeftToRight
            }
            ImageView{
                minWidth: 200
            }
            Container{
                Label{
                    text: bookName
                }
                Label{
                    text: bookAuthor
                }
                Label{
                    text: bookRating
                }
            }
        }
        Container {
            background: Color.DarkBlue
            minHeight: 500
            horizontalAlignment: HorizontalAlignment.Fill
            verticalAlignment: VerticalAlignment.Fill
            Label {
                multiline: true
                text: bookDesctiption
            }
        }
//        Button{
//            text: "See Reviews"
//            onClicked: {
//                //todo open url    
//            }
//        }
    
    }
}

