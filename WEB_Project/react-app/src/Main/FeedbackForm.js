import React from "react"
import { Button } from "reactstrap"
import 'bootstrap/dist/css/bootstrap.css';
import {Redirect} from "react-router-dom"


class FeedbackForm extends React.Component{

constructor(){
    super()
    this.state={
        Comment : "",
        Anonymous : false,
        Publishable : false,
        Redirect : false
    }
    this.handleChange=this.handleChange.bind(this)
    this.handleSubmit=this.handleSubmit.bind(this)
}


handleChange(event){
    const {name, value, type, checked} = event.target
    type === "checkbox" ? this.setState({ [name]: checked }) : this.setState({ [name]: value })

}

handleSubmit = (event) => {
    event.preventDefault()

    const appReviewFeedbackInfo = {
        Comment : this.state.Comment,
        Anonymous : this.state.Anonymous,
        Publishable : this.state.Publishable,
    }

    alert('A form was submitted ');
    const url="http://localhost:51916/appreviewfeedback"
    fetch(url,{
        method: "POST",
        headers: {  contentType: "application/json"},
        body: JSON.stringify(appReviewFeedbackInfo)})
        .then(response => response.json())
        .then(res => {
            if(res)
            {
                //success
                //this.setstate({this.state.message = success or smth})
            }
        } )
        this.setState({Redirect : true})
    
}

render(){


return(
<div className={this.props.class}>
    {this.state.Redirect ? <Redirect to="/"/> : null}
    <form onSubmit={this.handleSubmit}>
        <table>

        <tr>
            <td>
            <label height="1px" >Comment </label>
            </td>
            <td>
            <textarea 
                type="text" 
                value={this.state.Comment} 
                name="Comment" 
                placeholder="Comment" 
                onChange={this.handleChange} 
                width="500"
                height="250"
            />
            </td>
        </tr>
        <tr>
            <td>
            <label>Anonymous </label> 
            </td>
            <td>
            <input type="checkbox" name="Anonymous"/>
            </td>
        </tr>
        
 
        <tr>
                <td>
            <label>Publishable </label>
                </td>
            <td>
            
            <input type="checkbox" name="Publishable"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <Button color="primary" style={{margin : "1vh"}}>Submit Survey</Button>
            </td>
        </tr>

        </table>
    </form>

</div>)


}

}

export default FeedbackForm