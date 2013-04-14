// Default empty project template
#ifndef BookLab_HPP_
#define BookLab_HPP_

#include <QObject>

namespace bb { namespace cascades { class Application; }}

/*!
 * @brief Application pane object
 *
 *Use this object to create and init app UI, to create context objects, to register the new meta types etc.
 */
class BookLab : public QObject
{
    Q_OBJECT
public:
    BookLab(bb::cascades::Application *app);
    virtual ~BookLab() {}
};


#endif /* BookLab_HPP_ */
