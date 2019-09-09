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
        public resumer: boolean,
        public internship: number,
        public credits: number,
        public programmingLanguages: string,
        public interestInCS: string,
        public sigs: string,
        public majorEvent: string,
        public competing: string,
        public slackAccept: boolean,
        public paymentRecipt: number,
        public username: string,
        public userStatus: number
    ){

    }
}
