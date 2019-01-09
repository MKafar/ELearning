import React, { Component } from 'react';
import { Header, Button } from 'semantic-ui-react';

import './StudentCoding.scss';
import CodeMirror from '../../components/CodeMirror/CodeMirror';
import OpenNewWindow from '../../components/Modules/OpenNewWindow';


class StudentCoding extends Component {

    constructor(props) {
        super(props);
        this.state = {
            showComponent: false,
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

    render() {

        return (
            <div className='codingStudent'>
                <Header size='large'>Imię i nazwisko Tytuł zadania <Button className="exercisedeatilsbutton" onClick={this._onButtonClick}>Treść zadania</Button></Header>
                {this.state.showComponent ?
                        <OpenNewWindow close={this._onClose} htmlCode={"Treść zadania"} />
                        : null
                }
                
                <div className='codingContainer'>
                        <CodeMirror assignmentID={this.props.match.params.exerciseTodayDetailID}/>
                </div>
            </div>
        );
    }
}

export default StudentCoding;