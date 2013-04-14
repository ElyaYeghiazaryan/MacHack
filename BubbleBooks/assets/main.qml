// Default empty project template
import bb.cascades 1.0
//import "kits.js" as JSKits

// creates one page with a label
NavigationPane {
    id: bookNav
    BookLab {
    }
    onPopTransitionEnded: {
        page.destroy();
    }

}


