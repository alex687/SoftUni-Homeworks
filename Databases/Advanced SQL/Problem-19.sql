-- Insert Groups
INSERT Groups VALUES ('Green');
INSERT Groups VALUES ('Blue');
INSERT Groups VALUES ('Red');

-- Insert users at group
INSERT Users VALUES ('usr1', '12345', 'Alf', 'Dimitrov',  GETDATE(), 2);
INSERT Users VALUES ('usr2', '123456', 'Jerry', 'Mishoka', GETDATE(), 3);
