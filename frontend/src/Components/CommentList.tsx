import { SyntheticEvent } from 'react';
import { CommentModel } from '../Models/CommentModel';
import CommentItem from './CommentItem';

type Props = {
    comments: CommentModel[];
    onCommentDelete: (e: SyntheticEvent) => void;
}

const CommentList = ({comments, onCommentDelete}: Props) => {

  
  return (
    <div className="commentlist">
      {comments ?
      comments.map((comment, i) => {
        return <CommentItem comment={comment} id={i} onCommentDelete={onCommentDelete} />;
      }) : ""}
    </div>
  );
};

export default CommentList