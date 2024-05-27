import axios from "axios";
import { TopicModel } from "../Models/TopicModel";

const api = "http://localhost:5196/api/topic";

// export const topicPostAPI = async(title: string) => {
    // try {

    //     const data = await axios.post<Topic>(api + `${topic}`, {
    //         title: name,
    //         content: content,
    //     })
    // } catch(error) {

    // }
// }

export const topicGetAPI = async() => {
    try {
        const data = await axios.get<TopicModel[]>
        (api);
        return data;
    } catch (error) {
        console.log(error);
    }
}