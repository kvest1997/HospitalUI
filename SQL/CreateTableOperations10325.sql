/*Создание таблицы операций*/
CREATE TABLE Operations (
	Id int identity(1,1) NOT NULL,
	PatientId int  NOT NULL,
	ExaminationResultId int NOT NULL,
	DoctorId int NOT NULL,
	NameOperation nvarchar(512),
	TypeOperation nvarchar(258),
	CONSTRAINT PK_OperationId PRIMARY KEY CLUSTERED
	(
		Id ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	
);

/*Создание ключей*/
ALTER TABLE Operations WITH CHECK ADD CONSTRAINT FK_Operations_PatientId FOREIGN KEY(PatientId)
REFERENCES Patients(Id)

ALTER TABLE Operations WITH CHECK ADD CONSTRAINT FK_Operations_ExaminationResultId FOREIGN KEY(ExaminationResultId)
REFERENCES ExaminationResults(Id)

ALTER TABLE Operations WITH CHECK ADD CONSTRAINT FK_Operations_DoctorId FOREIGN KEY(DoctorId)
REFERENCES Doctors(Id)