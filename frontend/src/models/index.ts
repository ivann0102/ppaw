export class User {
  constructor(
    public userId: number,
    public userName: string,
    public email: string,
    public imageLink: string,
    public authType: string,
    public role: string
  ) {}
}

export class Post {
  constructor(
    public postId: number | undefined,
    public heading: string = "",
    public postText: string = "",
    public postDate: Date | undefined,
    public topicId: number = 0,
    public userId: number = 0,
    public parentPostId: number | undefined,
    public topic: string | undefined,
    public user: string | undefined,
    public images: string[] | undefined
  ) {}
}

export class PostModel {
  constructor(
    public heading: string = "",
    public postText: string = "",
    public parentPostId: number = 0,
    public topicId: number = 0,
    public userId: number = 0,
    public topic: string | undefined,
    public user: string | undefined
  ) {}
}
export class Topic {
  constructor(public topicId: number, public topicName: string) {}
}
