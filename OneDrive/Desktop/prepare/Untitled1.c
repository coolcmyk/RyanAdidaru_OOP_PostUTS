#include <QtCore/QCoreApplication>
#include <QtCore/QString>
#include <QtCore/QDebug>

int main(int argc, char *argv[]) {
    // Create a Qt application object
    QCoreApplication app(argc, argv);

    // Use QString (a Qt string class) to manipulate strings
    QString message = "Hello, Qt!";
    
    // Print the message to the console using qDebug
    qDebug() << message;

    // Exit the application
    return app.exec();
}

