-- Report the first name, last name, city and state of each person in the 'Person' table.
-- If the address of a 'personId' is not present in the 'Address' table, report 'null' instead.
SELECT firstName, lastName, city, state
FROM Person
LEFT JOIN Address on Person.personId = Address.personId;
