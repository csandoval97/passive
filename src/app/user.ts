export class User {
    constructor(
        public id: number,
        public basicInformation: string,
        public firstName: string,
        public lastName: string,
        public preferredName: string,
        public phone: string,
        public nonUICEmailAddress: string,
        public netid: string,
        public uin: string,
        public schoolYear: string,
        public college: string,
        public major: string,
        public commute: string,
        public resume: boolean,
        public internship: number,
        public credit: number,
        public programmingLanguages: string,
        public interestInCS: Array<string>,
        public sigs: Array<string>,
        public majorEvent: Array<string>,
        public competing: Array<string>,
        public slackAccept: boolean,
        public paymentRecipt: number,
        public username: string,
        public userStatus: number
    ){

    }
}
