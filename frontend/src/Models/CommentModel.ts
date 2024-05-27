// export type CommentPost = {
//     title: string;
//     content: string;
// }

// export type CommentGet = {
//     title: string;
//     content: string;
//     createdBy: string;
// }

export type CommentModel = {
    id: number,
    subject: string;
    content: string;
    topicId: number;
}

export type CommentPostModel = {
    subject: string;
    content: string;
}
