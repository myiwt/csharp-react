import axios from "axios";
import { CommentModel, CommentPostModel } from "../Models/CommentModel";

const api = "http://localhost:5196/api/comment";

export const commentPostAPI = async(
    subject: string,
    content: string,
    topicId: number) => {
    try {
        const data = await axios.post<CommentPostModel>(api + `/${topicId}`, {
            subject: subject,
            content: content,
        })
        return data;
    } catch(error) {
        // if (error instanceof Error) {
        //     console.log(error.message);
        // }
        console.log(error);
    }
}

export const commentGetAPI = async(topic: string) => 
{
    try {
        const encodedTopic = topic.replace(' ', '%20');
        const data = await axios.get<CommentModel[]>
        (api + `?name=${encodedTopic}`);
        return data;
    } catch (error) {
        // if (error instanceof Error) {
        //     console.log(error.message);
        // }
        console.log(error);
    }
}

export const commentDeleteAPI = async(id: number) =>
{
    try {
        const data = await axios.delete<CommentModel>(api + `/${id}`);
        return data;
    } catch (error) {
        console.log(error);
    }
} 