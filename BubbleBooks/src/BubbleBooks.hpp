// Default empty project template
#ifndef BubbleBooks_HPP_
#define BubbleBooks_HPP_

#include <QObject>

namespace bb { namespace cascades { class Application; }}

/*!
 * @brief Application pane object
 *
 *Use this object to create and init app UI, to create context objects, to register the new meta types etc.
 */
class BubbleBooks : public QObject
{
    Q_OBJECT
public:
    BubbleBooks(bb::cascades::Application *app);
    virtual ~BubbleBooks() {}
};


#endif /* BubbleBooks_HPP_ */
