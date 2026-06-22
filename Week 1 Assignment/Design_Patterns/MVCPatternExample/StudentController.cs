namespace MVCPatternExample
{
    public class StudentController
    {
        private readonly Student _model;
        private readonly StudentView _view;

        public StudentController(Student model, StudentView view)
        {
            _model = model;
            _view = view;
        }

        // Getter and Setter methods for Student data (bridging)
        public string StudentName
        {
            get => _model.Name;
            set => _model.Name = value;
        }

        public string StudentId
        {
            get => _model.Id;
            set => _model.Id = value;
        }

        public string StudentGrade
        {
            get => _model.Grade;
            set => _model.Grade = value;
        }

        // Command the view to render details
        public void UpdateView()
        {
            _view.DisplayStudentDetails(_model.Name, _model.Id, _model.Grade);
        }
    }
}
