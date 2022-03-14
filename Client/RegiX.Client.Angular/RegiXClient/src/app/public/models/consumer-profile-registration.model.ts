export class ConsumerProfileRegistrationModel {
    public name: string = null;
    public userName: string = null;
    public email: string = null;
    public password: string = null;
    public additionalAttributes: {
      [name: string]: string;
    } = null;
    // public additionalAttributes: {
    //   key: string;
    //   value: string;
    // }[] = [];
    public identifierType: string = null;
    public identifier: string = null;

    constructor(init: Partial<ConsumerProfileRegistrationModel>) {
      this.additionalAttributes = {};
      if (init) {
        this.name = init.name;
        this.userName = init.userName;
        this.email = init.email;
        this.password = init.password;
        this.additionalAttributes = init.additionalAttributes;
        this.identifierType = init.identifierType;
        this.identifier = init.identifier;
      }
    }

  }
