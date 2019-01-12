import React, { Component } from 'react';
import { Header, Button } from 'semantic-ui-react';
import axios from '../../axios';

import './StudentCoding.scss';
import CodeMirror from '../../components/CodeMirror/CodeMirror';
import OpenNewWindow from '../../components/Modules/OpenNewWindow';


class StudentCoding extends Component {

    constructor(props) {
        super(props);
        this.state = {
            showComponent: false,
            assignment: null,
            assignmentData: null,
            variantData: null,
        }
        this._onButtonClick = this._onButtonClick.bind(this);
        this._onClose = this._onClose.bind(this);
    }
    _onButtonClick = () => {
        this.setState({ showComponent: true });

    }
    _onClose = () => {
        this.setState({ showComponent: false });
    }
    componentWillMount = () => {
        this.setState({ assignment: this.props.match.params.exerciseTodayDetailID });
    }
    componentDidMount = () => {
        axios.get('/api/Assignments/GetById/' + this.state.assignment)
            .then(response => {

                console.log('PresentCode', response.data);
                this.setState({ assignmentData: response.data });

            }).catch(error => {
            console.log(error.response);
        })
        
    }
    
    render() {
        console.log("Coding", this.props);

        return (
             this.state.assignmentData ?
                <div className='codingStudent'>
                    <Header size='large'>{this.state.assignmentData.exercisetitle} <Button className="exercisedeatilsbutton" onClick={this._onButtonClick}>Treść zadania</Button></Header>
                    {this.state.showComponent ?
                        <OpenNewWindow close={this._onClose} htmlCode={this.state.assignmentData.content} />
                        : null
                    }

                    <div className='codingContainer'>
                        <CodeMirror assignmentID={this.props.match.params.exerciseTodayDetailID} />
                    </div>
                </div> : null
        );
    }
}

export default StudentCoding;