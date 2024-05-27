import { SyntheticEvent } from 'react';
import { CommentModel } from '../Models/CommentModel'

type Props = {
    comment: CommentModel,
    id: number;
    onCommentDelete: (e: SyntheticEvent) => void;
}

const CommentItem = ({comment, id, onCommentDelete } : Props) => {
  return (
    <div className={'comment comment_'+id.toString()}>
      <div className="title">

      <form onSubmit={onCommentDelete}>
        <input hidden={true} value={comment.id} />
        <button className="delete">
          Delete
        </button>
      </form>
        <p className="commentsubject">{comment.subject}</p>
      </div>        
        <p className="commentcontent">{comment.content}</p>
    </div>
  )
}

export default CommentItem