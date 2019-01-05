import React, { Component } from 'react';
import NewWindow from 'react-new-window';

class OpenNewWindow extends Component {
    
    componentDidMount = () => {
        //const code = this.props.htmlCode;
        console.log(this.props);
    }

    render() {
        const html = <p>Jestem html</p>;
        const string = '<p>Jestem string</p>';
        //const code = this.props.htmlCode;
        return (
            <NewWindow>
                <button onClick={this.props.close}>Zamknij</button>
                <h1>Hejka jestem</h1>
                {html}
                {string}
                {this.props.htmlCode}
            </NewWindow>
        )
    }
}
export default OpenNewWindow;