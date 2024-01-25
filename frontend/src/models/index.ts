export class User {
  public userId: number | undefined;
  public userName: string | undefined;
  public email: string | undefined;
  public imageLink: string | undefined;
  public authType: string | undefined;
  public role: string | undefined;
}

export class LoginModel {
  public userName: string | undefined;
  public password: string | undefined;
}

export class Post {
  public postId: number | undefined;
  public heading: string = "";
  public postText: string = "";
  public postDate: Date | undefined;
  public topicId: number = 0;
  public userId: number = 0;
  public parentPostId: number | undefined;
  public topic: string | undefined;
  public user: string | undefined;
  public postImages: string[] | undefined;
}

export class PostModel {
  public heading: string = "";
  public postText: string = "";
  public parentPostId: number = 0;
  public topicId: number = 0;
  public userId: number = 0;
  public topic: string | undefined;
  public user: string | undefined;
}
export class Topic {
  public topicId: number | undefined;
  public topicName: string | undefined;
}
