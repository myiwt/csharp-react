import { CommentModel } from "../Models/CommentModel";
import { SyntheticEvent } from "react";
import CommentList from "./CommentList";

type Props = {
    onCommentDelete: (e: SyntheticEvent) => void;
    comments: CommentModel[] | null;
}

const TopicComment = ({ onCommentDelete, comments }: Props) => {

    return (
      <div className = "comments">
        <h3>Comments</h3>
      <CommentList comments={comments!} onCommentDelete={onCommentDelete} />
      </div>      
    )
}

export default TopicComment