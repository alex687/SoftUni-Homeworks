CREATE DATABASE `trainings`;

USE DATABASE  `trainings`;

DROP TABLE IF EXISTS `training_centers`;

CREATE TABLE `training_centers` (
	`id`  int(11) NOT NULL AUTO_INCREMENT,
	`name` varchar(45) NOT NULL,
	`description` text,
	`url` varchar(2083),
	PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `courses`;

CREATE TABLE `courses` (
    `id`  int(11) NOT NULL AUTO_INCREMENT,
	`name` varchar(45) NOT NULL,
	`description` text,
	PRIMARY KEY (`id`)
);

CREATE TABLE `trainings`.`timetable` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `course_id` INT NOT NULL,
  `training_center_id` INT NOT NULL,
  `start_date` DATE NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_TIMETABLE_COURSES_idx` (`course_id` ASC),
  INDEX `FK_TIMETABLE_TRAINING_CENTERS_idx` (`training_center_id` ASC),
  CONSTRAINT `FK_TIMETABLE_COURSES`
    FOREIGN KEY (`course_id`)
    REFERENCES `trainings`.`courses` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_TIMETABLE_TRAINING_CENTERS`
    FOREIGN KEY (`training_center_id`)
    REFERENCES `trainings`.`training_centers` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    );


SELECT tc.name as `traning center`, t.start_date as `start date`, c.name as `course name`, c.description as `more info`
FROM `timetable` t
JOIN `courses` c ON c.id = t.course_id
JOIN `training_centers` tc ON  tc.id = t.training_center_id
ORDER BY t.start_date, t.id