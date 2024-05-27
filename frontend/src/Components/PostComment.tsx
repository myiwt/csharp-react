import { TopicModel } from "../Models/TopicModel";

type Props = {
    topicId: number;
    onCommentCreate: any;
}

const PostComment = ({ topicId, onCommentCreate }: Props) => {
  return (
    <div className="postcomment">
        <p>Post a comment</p>
        <form onSubmit={onCommentCreate}>
            <input type="text" id="title" placeholder="Title" />
            <input type="text" id="comment" placeholder="Comment" />
            <button type="submit">
            Post
        </button>
        </form>
    </div>
  )
}

export default PostComment