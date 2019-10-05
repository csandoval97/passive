using System.ComponentModel.DataAnnotations;

namespace passive.ACMAD
{
    public enum objectClass
    {
        user, group, computer
    }
    public enum returnType
    {
        distinguishedName, ObjectGUID
    }
    public enum Major
    {
        [Display(Name = "Other")] Other,

    }

    public enum Title
    {
        [Display(Name = "Other")] Other,
        [Display(Name = "President")] President,
        [Display(Name = "Vice President")] VicePresident,
        [Display(Name = "Treasurer")] Treasurer,
        [Display(Name = "Advisor")] Advisor,
        [Display(Name = "Council Member")] CouncilMember,
        [Display(Name = "Member")] Member,

    }

    public enum MemberType
    {
        Other,
        Faculty,
        Student,
        Alumni
    }
    public enum College
    {
        [Display(Name = "Other")] Other,
        [Display(Name = "Applied Health Sciences")] AppliedHealthSciences,
        [Display(Name = "Architecture, Design, Arts")] ArchitectureDesignArts,
        [Display(Name = "Business Administration")] BusinessAdministration,
        [Display(Name = "Education")] Education,
        [Display(Name = "Engineering")] Engineering,
        [Display(Name = "Liberal Arts and Sciences")] LiberalArtsandSciences,
        [Display(Name = "Nursing")] Nursing,
        [Display(Name = "Pharmacy")] Pharmacy,
        [Display(Name = "Public Health")] PublicHealth,
        [Display(Name = "Urban Planning and Public Affairs")] UrbanPlanningandPublicAffairs,
    }

    public enum Department
    {
        [Display(Name = "Other")] Other,
        [Display(Name = "Biomedical and Health Information Sciences")] BiomedicalandHealthInformationSciences,
        [Display(Name = "Disability and Human Development")] DisabilityandHumanDevelopment,
        [Display(Name = "Kinesiology and Nutrition")] KinesiologyandNutrition,
        [Display(Name = "Preprofessional Studies")] PreprofessionalStudies,
        [Display(Name = "Rehabilitation Sciences")] RehabilitationSciences,
        [Display(Name = "Architecture")] Architecture,
        [Display(Name = "Art")] Art,
        [Display(Name = "Art History")] ArtHistory,
        [Display(Name = "Design")] Design,
        [Display(Name = "Music")] Music,
        [Display(Name = "Theatre")] Theatre,
        [Display(Name = "Accounting")] Accounting,
        [Display(Name = "Business Administration")] BusinessAdministration,
        [Display(Name = "Finance")] Finance,
        [Display(Name = "Information and Decision Sciences (IDS)")] InformationandDecisionSciences,
        [Display(Name = "Managerial Studies")] ManagerialStudies,
        [Display(Name = "CBA Minors")] CBAMinors,
        [Display(Name = "Curriculum and Instruction")] CurriculumandInstruction,
        [Display(Name = "Educational Psychology")] EducationalPsychology,
        [Display(Name = "Bioengineering")] Bioengineering,
        [Display(Name = "Chemical Engineering")] ChemicalEngineering,
        [Display(Name = "Civil and Materials Engineering")] CivilandMaterialsEngineering,
        [Display(Name = "Computer Science")] ComputerScience,
        [Display(Name = "Electrical and Computer Engineering")] ElectricalandComputerEngineering,
        [Display(Name = "Interdisciplinary")] Interdisciplinary,
        [Display(Name = "Mechanical and Industrial Engineering")] MechanicalandIndustrialEngineering,
        [Display(Name = "African American Studies")] AfricanAmericanStudies,
        [Display(Name = "Anthropology")] Anthropology,
        [Display(Name = "Biochemistry")] Biochemistry,
        [Display(Name = "Biological Sciences")] BiologicalSciences,
        [Display(Name = "Chemistry")] Chemistry,
        [Display(Name = "Classics and Mediterranean Studies")] ClassicsandMediterraneanStudies,
        [Display(Name = "Communication")] Communication,
        [Display(Name = "Criminology Law and Justice")] CriminologyLawandJustice,
        [Display(Name = "Earth and Environmental Sciences")] EarthandEnvironmentalSciences,
        [Display(Name = "Economics")] Economics,
        [Display(Name = "English")] English,
        [Display(Name = "French and Francophone Studies")] FrenchandFrancophoneStudies,
        [Display(Name = "Gender and Women's Studies")] GenderandWomensStudies,
        [Display(Name = "Germanic Studies")] GermanicStudies,
        [Display(Name = "Global Asian Studies")] GlobalAsianStudies,
        [Display(Name = "Hispanic and Italian Studies")] HispanicandItalianStudies,
        [Display(Name = "History")] History,
        [Display(Name = "Integrated Health Studies")] IntegratedHealthStudies,
        [Display(Name = "Interdepartmental")] Interdepartmental,
        [Display(Name = "International Studies")] InternationalStudies,
        [Display(Name = "Latin American and Latino Studies")] LatinAmericanandLatinoStudies,
        [Display(Name = "Linguistics")] Linguistics,
        [Display(Name = "Mathematics Statistics and Computer Science")] MathematicsStatisticsandComputerScience,
        [Display(Name = "Moving Image Arts")] MovingImageArts,
        [Display(Name = "Neuroscience")] Neuroscience,
        [Display(Name = "Philosophy")] Philosophy,
        [Display(Name = "Physics")] Physics,
        [Display(Name = "Polish, Russian, and Lithuanian Studies")] PolishRussianandLithuanianStudies,
        [Display(Name = "Political Science")] PoliticalScience,
        [Display(Name = "Psychology")] Psychology,
        [Display(Name = "Religious Studies")] ReligiousStudies,
        [Display(Name = "Sociology")] Sociology,
        [Display(Name = "Nursing")] Nursing,
        [Display(Name = "Pharmacy")] Pharmacy,
        [Display(Name = "Public Health")] PublicHealth,
        [Display(Name = "Public Administration")] PublicAdministration,
        [Display(Name = "Urban Planning and Policy")] UrbanPlanningandPolicy,
    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }
}