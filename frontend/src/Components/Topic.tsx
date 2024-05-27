import { SyntheticEvent, useEffect, useState } from "react";
import { TopicModel } from "../Models/TopicModel";
import PostComment from "./PostComment";
import TopicComment from "./TopicComment";
import { commentPostAPI, commentGetAPI, commentDeleteAPI } from "../Services/CommentService";
import { CommentModel } from "../Models/CommentModel";

type Props = {
    topic: TopicModel,
    id: number,
    comments: CommentModel[] | null
}

type CommentFormInputs = {
    target: any,
    topic: number,
  };

function Topic({ topic, id }: Props) {

  useEffect(() => {
    getComments();}, []);

    const topicId = topic.id;
    const [comments, setComments ] = useState<CommentModel[] | null>(null);

    const getComments = () => {
        commentGetAPI(topic.name).then((response) => {
            setComments(response?.data!);
        })
    }

    const onCommentCreate = (e: CommentFormInputs) => {
        commentPostAPI(e.target[0].value, e.target[1].value, topicId)
          .then((res) => {
            if (res) {
              getComments();
            }
          })
          .catch((e) => {
            console.log(e);
          });
    };

    const onCommentDelete = (e: any) => {
      e.preventDefault();
      commentDeleteAPI(parseInt(e.target[0].value))
        .then((response) => {
          if (response?.status == 200) {
            getComments();
          }
        })
        .catch((e) => {
          console.log(e);
        });
    };

    return (
        <div className={'topic topic_'+id.toString()}>
            <h2>{ topic.name }</h2>
            <h3>{ topic.description }</h3>
            < TopicComment onCommentDelete={onCommentDelete} comments={comments} />
            < PostComment topicId={topic.id} onCommentCreate={onCommentCreate}/>
        </div>
  )
}

export default Topic