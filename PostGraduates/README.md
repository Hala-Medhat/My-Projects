This project is a simulation of the postgrad system 
 //////////////////Database///////////////////////
 Database was developed using sql locally on the computer for our users instructor - admin - student
 
 ////////////////FrontEnd////////////////////////
 The functionality of our project was simulated using a frontend developed by ASP.NET (c#)
 
 /////////////////////////////////Here is project description ///////////////////////////////
 
 //////////Project Overview////////////
 
The GUC has a postgrad office responsible for masters and PhD. programs. The postgrad office wants to
create a system to keep track of students doing their postgrad studies as well as manage the process of
students taking prerequisite courses for the postgrad studies. Students need to register for their master
or PhD through this system.
The aim of the project is to implement a system that provides these features to the parties involved.

////////////Systems Requirements///////////////
This section describes the different requirements that the platform has to include.

2.1 Users
Different types of users can use the postgrad system. Users are either: Admin, Supervisor or Student.
Any user can view, and search any information related to the theses and publications available on the
system.

2.1.1 Admin
The admin can update the details stored in the system.

2.1.2 Student
Two different types of students could register; non GUCian and Gucian. Students can only be of the two
types. Any student should have a name (firstname and lastname), email, type(Matser or PhD), GPA,
address, and faculty. The student can also have mobile number(s) . After registration an automatic unique
ID (numeric) should be set to each student and displayed to them. Furthermore, the GUCian student has
an undergraduate ID. After finishing the Master degree, a student can register for a PhD. The system
keeps track of all the information about theses in both cases.

2.1.3 Supervisor
A supervisor is responsible for the supervision of students doing their theses. The supervisor has a name,
faculty, ID, and email. The supervisor can view and evaluate the progress report of his/her students.
1

2.2 Thesis
Each thesis has a unique serial number, title, type (Master or PhD), field, startDate, endDate, seminarDate, and number of extensions needed (in case the student did not finish it before the endDate). The
postgrad office should be able to calculate the number of years spent in the thesis since the start date. A
student can make his/her Master and PhD in the university so the system needs to keep track of his/her
theses in these two cases. Each thesis has a payment that should be completed. Each thesis has its own
defense.

2.3 Defense
A student represents his/her thesis work in a defense. It has a date, grade, and location. Furthermore,
examiners attend to evaluate the defense and provide his/her comments. An examiner has a name, field
of work, and may be a national or international examiner.

2.4 Progress report
A student can fill progress reports for a specific thesis. A progress report shows the progress state (numeric). A progress report has a description, date, and evaluation.

2.5 Course
Non GUCian student have to take courses. Each course has a unique ID, code, and credit hours. The
postgard office keeps track of the grade the student in this course. Each course has fee that should be
paid by the registered student.

2.6 Publication
A student can publish different publications. Each publication has a date when it will be posted , title
of the publication , host which is the name of the conference it will be posted in , and place which is the
location of the conference. The postgrad office keeps track if it is accepted. A publication belongs to one
or more theses.

2.7 Payment
The postgrad office keeps track of the total amount, fund percentage, number of installments, and payment
ID. Some publications have payment. Each payment can be divided into one or more installments. Each
installment will have a date, amount, and status (paid or not).
 
 
