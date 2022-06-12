import React, {useState, useEffect} from 'react';
import axios from 'axios';

const Home = () => {
    const[posts, setPosts] = useState([]);

    useEffect(() => {
        const getPosts = async () => {
            const{data} = await axios.get(`/api/LakewoodScoop/scrape`);
            setPosts(data);
        }
        getPosts();
    }, []);

    return(
        <div className='container mt-5'>
            <div className='col-md-12'>
                {!!posts.length && <table className='table table-hover table-striped table-bordered'>
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Title</th>
                            <th>Text</th>
                            <th>Amount of Comments</th>
                        </tr>
                    </thead>
                    <tbody>
                        {posts.map((post, idx) => {
                            return <tr key={idx}>
                                <td><img src={post.image}/></td>
                                <td>
                                    <a href={post.link} target='_blank'>{post.title}</a>
                                </td>
                                <td>{post.text}</td>
                                <td>{post.amountComments}</td>
                            </tr>
                        })}
                    </tbody>
                    </table>}
            </div>
        </div>
    )

}

export default Home;