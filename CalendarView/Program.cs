using Presentation;

namespace CalendarView
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new ConsoleViewMain();
            var presenter = new ViewMainPresenter(view);
            presenter.Run();
        }
    }
}
