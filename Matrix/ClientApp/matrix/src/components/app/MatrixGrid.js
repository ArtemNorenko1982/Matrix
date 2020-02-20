import React, { Component } from 'react';
import { CSVLink, CSVDownload } from "react-csv";
import './MatrixGrid.css'
export class MatrixGrid extends Component {

    const = {
        defaultMatrixRowCount: Number,
        defaultMatrixColCount: Number
    };

    constructor(props) {
        super(props);
        this.state = {
            testMatrix: [[]],
            loading: true,
            row: 2,
            col: 2
        }

        this.defaultMatrixRowCount = 2;
        this.defaultMatrixColCount = 2;
    }

    render() {
        return (
            <div>
                <form id="matrixItem">
                    <div>
                        <input id="r" type="Number" defaultValue={this.state.row} onChange={this.handleRowCount}></input> x <input id="c" type="Number" defaultValue={this.state.col} onChange={this.handleColCount}></input>
                    </div>
                    {this.state.testMatrix.map((row, item) =>
                        (<div id={item} key={item}>
                            {row.map((col, element) => <span key={element}> | {col} | </span>)}
                        </div>))
                    }
                </form>
                <br></br>
                <div>
                    <button className="btn btn-primary" onClick={this.load}>Load from csv</button>
                    <button className="btn btn-primary" onClick={this.generate}>Generate random square matrix</button>
                    <button className="btn btn-primary" onClick={this.rotateClockWise}>Rotate clock wise</button>
                    <button className="btn btn-primary" onClick={this.rotateAntiClockWise}>Rotate anti clockwise</button>
                    <CSVLink className="btn btn-primary" filename={"matrix.csv"} data={this.state.testMatrix}>export</CSVLink>
                </div>
            </div>
        );
    }

    rotateClockWise = async () => {
        const response = await fetch('api\\matrix\\clockwise-rotation');
        var data = await response.json();
        this.setState({ testMatrix: data, loading: false });
    }

    rotateAntiClockWise = async () => {
        const response = await fetch('api\\matrix\\anti-clockwise-rotation');
        var data = await response.json();
        this.setState({ testMatrix: data, loading: false });
    }

    generate = () => {
        var rows = this.state.row;
        var columns = this.state.col;
        if (this.isUserDataValid(rows, columns) === true) {
            var customMatrix = this.buildRandomMatrix(rows, columns);
            this.setState({ testMatrix: customMatrix, loading: false });
            this.post(customMatrix);
        }
        else {
            alert("Please, use square matrix, at least 2x2.");
        }
    }

    async post(matrix) {
        await fetch('api\\matrix\\store',
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ matrix: matrix })
            })
            .then(res => (res.ok ? res : Promise.reject(res)))
            .then(res => res.json());
    }

    handleRowCount = (e) => {
        this.setState({ row: e.target.value });
    }

    handleColCount = (e) => {
        this.setState({ col: e.target.value });
    }

    //demo
    load() {
        alert("Note - only full version allows you to load matrix from external source.");
    }

    export = () => {
        //alert("Note - only full version allows you to export matrix data.");
    }


    // service handlers
    buildRandomMatrix = (row, col) => {
        var randomMatrix = new Array(col);

        for (let i = 0; i < row; i++) {
            randomMatrix[i] = new Array(i);
        }

        for (let matrixRow = 0; matrixRow < row; matrixRow++) {
            for (let matrixColumn = 0; matrixColumn < col; matrixColumn++) {
                randomMatrix[matrixRow][matrixColumn] = this.generateRandomNumber();
            }
        }
        return randomMatrix;
    }

    generateRandomNumber() {
        var digit = Math.floor(Math.random() * 900) + 100;
        return digit;
    }

    isUserDataValid(row, col) {
        var r = parseInt(row, 10);
        var c = parseInt(col, 10);
        var t = (r === c && r >= this.defaultMatrixRowCount);
        return t;
    }
}