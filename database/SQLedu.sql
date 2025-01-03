CREATE TABLE courses (
    id INT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT NOT NULL
);
CREATE TABLE students (
    id INT PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);

CREATE TABLE student_courses (
    student_id INT,
    course_id INT,
    PRIMARY KEY (student_id, course_id),
    FOREIGN KEY (student_id) REFERENCES students(id),
    FOREIGN KEY (course_id) REFERENCES courses(id)
);

INSERT INTO students (id, username, password) VALUES
(1, 'AhmedAli', 'pass123'),
(2, 'MohamedHassan', 'pass234'),
(3, 'SaraIbrahim', 'pass345'),
(4, 'MonaHassan', 'pass456'),
(5, 'YoussefKamal', 'pass567'),
(6, 'NohaSaid', 'pass678'),
(7, 'OmarTarek', 'pass789'),
(8, 'AmiraAhmed', 'pass890'),
(9, 'LailaHussein', 'pass901'),
(10, 'KhaledEslam', 'pass101'),
(11, 'HananSalem', 'pass112'),
(12, 'HassanMahmoud', 'pass1234'),
(13, 'EmanYoussef', 'pass1345'),
(14, 'RaniaMostafa', 'pass1456'),
(15, 'FaridaGamal', 'pass1567'),
(16, 'AliFathy', 'pass1678'),
(17, 'SalmaAdel', 'pass1789'),
(18, 'TamerIbrahim', 'pass1890'),
(19, 'BassantKhaled', 'pass1901'),
(20, 'HalaFouad', 'pass202'),
(21, 'KaremAhmed', 'pass213'),
(22, 'MariamAli', 'pass224'),
(23, 'HishamNabil', 'pass235'),
(24, 'NadiaSamir', 'pass246'),
(25, 'SherifFathy', 'pass257'),
(26, 'RamyEzzat', 'pass268'),
(27, 'MaiAyman', 'pass279'),
(28, 'HebaKamal', 'pass280'),
(29, 'MalakMostafa', 'pass291'),
(30, 'ZiadFahmy', 'pass301');

INSERT INTO student_courses (student_id, course_id) VALUES
(1, 1), (1, 2),
(2, 3), (2, 4),
(3, 5),
(4, 6), (4, 7), (4, 8),
(5, 9),
(6, 10), (6, 11),
(7, 12),
(8, 13), (8, 14), (8, 15),
(9, 1), (9, 2),
(10, 3), (10, 4),
(11, 5),
(12, 6), (12, 7), (12, 8),
(13, 9),
(14, 10), (14, 11),
(15, 12),
(16, 13), (16, 14), (16, 15),
(17, 1), (17, 2),
(18, 3), (18, 4),
(19, 5),
(20, 6), (20, 7), (20, 8),
(21, 9),
(22, 10), (22, 11),
(23, 12),
(24, 13), (24, 14), (24, 15),
(25, 1), (25, 2),
(26, 3), (26, 4),
(27, 5),
(28, 6), (28, 7), (28, 8),
(29, 9),
(30, 10), (30, 11);



INSERT INTO courses (id, title, description) VALUES
(1, 'Introduction to Python', 'Learn the basics of Python programming.'),
(2, 'Advanced JavaScript', 'Master advanced concepts in JavaScript.'),
(3, 'Data Science Basics', 'An introduction to data science techniques.'),
(4, 'Machine Learning Essentials', 'Understand the fundamentals of machine learning.'),
(5, 'Web Development with HTML & CSS', 'Build websites using HTML and CSS.'),
(6, 'React for Beginners', 'A beginner-friendly guide to React.js.'),
(7, 'Database Management with SQL', 'Learn to manage and query databases using SQL.'),
(8, 'Introduction to Cybersecurity', 'Basics of securing systems and networks.'),
(9, 'Mobile App Development with Flutter', 'Create cross-platform mobile apps using Flutter.'),
(10, 'Game Development with Unity', 'Learn how to develop games using Unity.'),
(11, 'Cloud Computing Basics', 'Introduction to cloud services and platforms.'),
(12, 'DevOps Fundamentals', 'Understand DevOps practices and tools.'),
(13, 'AI for Everyone', 'An introduction to artificial intelligence concepts.'),
(14, 'Blockchain Essentials', 'Learn the fundamentals of blockchain technology.'),
(15, 'Digital Marketing 101', 'Understand the basics of digital marketing strategies.');

SELECT * FROM students;


SELECT 
    student_courses.student_id AS student_id, 
    (SELECT username FROM students WHERE students.id = student_courses.student_id) AS username, 
    student_courses.course_id AS course_id, 
    (SELECT title FROM courses WHERE courses.id = student_courses.course_id) AS course_title
FROM 
    student_courses;


	SELECT 
    id AS student_id, 
    username
FROM 
    students
WHERE 
    id IN (
        SELECT student_id 
        FROM student_courses 
        WHERE course_id = (
            SELECT id 
            FROM courses 
            WHERE title = 'Introduction to Python'
        )
    );



	SELECT 
    id AS course_id, 
    title, 
    (
        SELECT COUNT(student_id) 
        FROM student_courses 
        WHERE course_id = courses.id
    ) AS student_count
FROM 
    courses;


	INSERT INTO student_courses (student_id, course_id) VALUES 
(1, 3); 


DELETE FROM student_courses 
WHERE 
    student_id = 1 AND course_id = 3; 


	UPDATE students 
SET 
    password = 'newpassword123' 
WHERE 
    username = 'AhmedAli';




