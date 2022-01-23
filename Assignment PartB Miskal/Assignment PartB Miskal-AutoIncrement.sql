CREATE DATABASE MISKALSCHOOL;

USE MISKALSCHOOL;

CREATE TABLE Course(
		
		CourseID INT IDENTITY(1,1) PRIMARY KEY,
		Title VARCHAR(30) NOT NULL,
		Stream VARCHAR(30) NOT NULL,
		Type VARCHAR(30) NOT NULL,
		StartDate DATE NOT NULL,
		EndDate DATE NOT NULL,
		
);


CREATE TABLE Student(
		StudentID INT IDENTITY(1,1) PRIMARY KEY,
		FirstName VARCHAR(30) NOT NULL,
		LastName VARCHAR(30) NOT NULL,
		BirthDate DATE NOT NULL,
		TuitionFees INT NOT NULL,
		
);

CREATE TABLE Trainer(
		TrainerID INT IDENTITY(1,1) PRIMARY KEY,
		FirstName VARCHAR(30) NOT NULL,
		LastName VARCHAR(30) NOT NULL,
		Subject VARCHAR(30) NOT NULL,
		
);

--Assignment-Course = One to many
--One Course can have multiple Assignments
--But an assignment must be related to only one course
CREATE TABLE Assignment(
		AssignmentID INT IDENTITY(1,1) PRIMARY KEY,
		Title VARCHAR(30) NOT NULL,
		Discription VARCHAR(100) NOT NULL,
		SubDateTime DATE NOT NULL,
		OralMark INT NOT NULL,
		TotalMark INT NOT NULL,
		CourseID INT NOT NULL,
		CONSTRAINT fk_courseid3 FOREIGN KEY(CourseID) REFERENCES Course(CourseID),
		
);


CREATE TABLE Course_Trainer(
	CourseID INT NOT NULL,
	TrainerID INT NOT NULL,
	PRIMARY KEY(CourseID,TrainerID),
	CONSTRAINT fk_courseid FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
	CONSTRAINT fk_trainerid FOREIGN KEY (TrainerID) REFERENCES Trainer(TrainerID)

);

CREATE TABLE Course_Student(
	CourseID INT NOT NULL,
	StudentID INT NOT NULL,
	PRIMARY KEY (CourseID,StudentID),
	CONSTRAINT fk_courseid1 FOREIGN KEY (CourseID) REFERENCES Course (CourseID),
	CONSTRAINT fk_studentid FOREIGN KEY (StudentID) REFERENCES Student (StudentID)
);




-----------------------Populate Tables-------------------

INSERT INTO Course (Title,Stream,Type,StartDate,EndDate)
VALUES
( 'CSharp', 'CB3', 'Full Time',('2021- 9 -10'), ('2022 -12- 10')),
( 'CSharp', 'CB3', 'Part Time', ('2021- 9- 10'), ('2022- 4- 10')),
( 'Java', 'CB3', 'Full Time', ('2021 -9- 11'), ('2022 - 12 - 11')),
( 'Java', 'CB3', 'Part Time', ('2021- 9- 11'), ('2022 - 4 -11'))


INSERT INTO Student (FirstName,LastName,BirthDate,TuitionFees)
VALUES
('Peter', 'Parker', ('1987- 1-2'), 2500),
('Brok', 'Lesnar', ('1991-4-7'), 2500),
('Edie', 'Guerero', ('1981-5-1'), 2500),
('Rey', 'Mysterio"', ('1993-3-2'), 2500),
('Dimitra', 'Nakou', ('1989-8-9'), 2500),
('Athina', 'Anton', ('1991-1-1'), 2500),
('Aris', 'Plexidas', ('1990-2-8 '), 2100),
('Ichigo', 'Rengoku', ('1981-1-3' ), 2300),
('Paulos', 'Adonakos', ('1981-1-3 '), 2500),
('Mixalis', 'Staxtouris', ('1981-1-3' ), 2300),
('Stelios', 'Chatzis', ('1981-1-3' ), 2300),
('Cheyenne', 'Jefferson',('1981-1-3 '), 2500),
('Muhammad', 'Hail', ('1981-1-3' ), 2500),
('Fion', 'Bassett', ('1981-1-3 '), 2300),
('Emelie', 'Williams', ('1981-1-3' ), 2500),
('Irene', 'Finnegan', ('1981-1-3' ), 2300),
('Joyce', 'Ferguson', ('1981-1-3' ), 2500),
('Time', 'Rowe', ('1981-1-3' ), 2500),
('Deborah', 'Dickinson', ('1981-1-3' ), 2500),
('Anika', 'Aroyo', ('1981-1-3' ), 2500)


INSERT INTO Trainer(FirstName,LastName,Subject)
VALUES
('Ektor','Gatsos','CSharp' ),
( 'Francis','Xavier','Java' ),
( 'Bruce','Banner','Javascript' ),
('Etrigan','Camelot','Javascript' ),
( 'Maria','Kalfa','SQL' ),
( 'Tony','Stark', 'Java' ),
( 'Vitalik','Buterin','CSharp'),
( 'Elon', 'Musk','SQL')

INSERT INTO Assignment(Title,Discription,SubDateTime,OralMark,TotalMark,CourseID)
VALUES
( 'Calculator', 'Create a Calculator', ('2021- 10- 3'), 50, 100,1),
( 'Website', 'Create a Website', ('2021- 11- 22'), 50, 100,1),
( 'Memory Game', 'Create a memory Game', ('2021- 12- 13'), 50, 100,2),
( 'Puzzle Game', 'Create a Puzzle Game', ('2021- 12-13'), 50, 100,2),
( 'Online Store', 'Build Your Own Online Store', ('2021- 12- 13'), 50, 100,3),
( 'Redesign', 'Redesign an Existing Website', ('2021-12-13'), 50, 100,3),
( 'Application', 'Create a Simple Application', ('2021-12-13'), 50, 100,4),
( 'Generator', 'Create a Random Number Generator', ('2021-12-13'), 50, 100,4)



INSERT INTO Course_Trainer(CourseID,TrainerID)
VALUES
(2,1),
(3,2),
(1,3),
(2,4),
(4,4),
(1,5),
(4,5),
(4,6),
(1,7),
(3,7),
(2,8),
(3,8)




INSERT Course_Student(CourseID,StudentID)
VALUES
(1,1),
(1,5),
(2,2),
(2,6),
(3,3),
(3,7),
(3,2),
(4,4),
(4,8),
(4,1),
(4,20),
(4,19),
(4,18),
(3,17),
(3,16),
(3,15),
(2,14),
(2,13),
(2,12),
(1,11),
(1,10),
(1,9)
          
