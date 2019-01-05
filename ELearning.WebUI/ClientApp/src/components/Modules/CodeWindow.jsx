import React, { Component } from 'react';
import CodeMirror from 'react-codemirror';

import './CodeWindow.scss';
import 'codemirror/lib/codemirror.css';
import 'codemirror/mode/clike/clike';
import 'codemirror/mode/htmlmixed/htmlmixed.js';
import 'codemirror/mode/htmlembedded/htmlembedded.js';
import 'codemirror/theme/neat.css';
import 'codemirror/addon/edit/closebrackets.js';
import 'codemirror/mode/xml/xml.js';
import 'codemirror/mode/css/css.js';


class CodeWindow extends Component {

    // constructor(props) {
    //     super(props);
    // };

    state = {
        name: 'CodeMirror',
        code: '',
        changeMode: false,
    };

    setCode = () => {

        this.props.getData(this.state.code);
        console.log(this.state.code);
    }
    sendCode = () => {
        console.log(this.state.code)
    }

    updateCode(newCode) {
        this.setState({
            code: newCode,
        });
        this.props.getData(newCode);
    }

    render() {
        let options = null;
        if (this.props.changeMode) {
            options = {
                lineNumbers: true,
                mode: 'text/x-c++src',
                theme: 'neat',
                autoCloseBrackets: true,
                readOnly: true
            };

        } else if (!this.props.changeMode) {
            options = {
                lineNumbers: true,
                mode: 'text/x-c++src',
                theme: 'neat',
                autoCloseBrackets: true,
            };
        }

        return (
            <div className='codeWindow'>
                <CodeMirror onChange={this.updateCode.bind(this)} value={this.props.code} options={options} />

            </div>
        );
    }
}
export default CodeWindow;
