import { useEffect, useState } from "react";
import { TopicModel } from "../Models/TopicModel";
import { topicGetAPI } from "../Services/TopicService";
import Topic from './Topic';


function TopicsList() {
    const [topicValues, setTopicValues] = useState<TopicModel[] | []> ([]);

    useEffect(() => {
        getTopics();
      }, []);

    const getTopics = () => {
        topicGetAPI()
        .then((response) => {
            if (response?.data) {
                setTopicValues(response?.data);
            }
        })
    }

  return (
    <div className="topicslist">
        {topicValues.length > 0 ? (
            topicValues.map((topic, i) => {
                return (
                        <Topic topic= { topic } id={i} />
                );
            })                
            ) : 
            (<p>There are no topics</p>)}
    </div>
  )
}

export default TopicsList