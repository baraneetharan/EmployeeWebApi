var chakram = require('chakram'),
    expect = chakram.expect;


describe('EmployeeCreateTest', function(){
	it('Create empdetails', function(){
		this.timeout(5000);
		return chakram.post("http://Localhost:5000/api/EmployeeMasters/",
			{
                "EmpId":0,"EmpName":"SueSmith","Designation":"Dev","Email":"soma@kgfsl.com","Phone":"898989898","Address":"CBE"            },
		 {
			headers: {
				'Content-Type': 'application/json'
			},
		})
		.then(function(response){
			//console.log(response.body);
			 expect(response).to.have.status(200);
			 expect(response).to.have.header('content-type', /json/);
		})
		return chakram.wait();
	})
});
//method 2
describe('EmployeeUpdateTest', function(){
	it('Updating employee details', function(){
		this.timeout(5000);
		return chakram.post("http://Localhost:5000/api/EmployeeMasters/",
			{
                "EmpID":"3","EmpName":"Somasundaram","Designation":"Dev","Email":"soma@kgfsl.com","Phone":"898989898","Address":"CBE"            },
		 {
			headers: {
				'Content-Type': 'application/json'
			},
			
			
		})
		.then(function(response){
			//console.log(response.body);
			 expect(response).to.have.status(200);
			 expect(response).to.have.header('content-type', /json/);
		})
		return chakram.wait();
	})
});
//method 3
describe('EmployeeDeleteTest', function(){
	it('delete employee details', function(){
		this.timeout(5000);
		// return chakram.delete("http://Localhost:5000/api/EmployeeMasters?EmpID=7",
			
		//  {
		// 	headers: {
		// 		'Content-Type': 'application/json'
		// 	},
		// })
		return chakram.post("http://Localhost:5000/api/EmployeeMasters/DeleteEmployeeMaster",
			{
                "EmpID":"3","EmpName":"Somasundaram","Designation":"Dev","Email":"soma@kgfsl.com","Phone":"898989898","Address":"CBE"            },
		 {
			headers: {
				'Content-Type': 'application/json'
			},
			
			
		})
		.then(function(response){
			//console.log(response.body);
	        expect(response).to.have.status(200);
			expect(response).to.have.header('content-type', /json/);
		})
		return chakram.wait();
	})
});
//get method
describe('EmployeeGetALLTest', function(){
	it('get all employees', function(){
		this.timeout(5000);
		return chakram.get("http://Localhost:5000/api/EmployeeMasters")
		.then(function(response){
			console.log(response.body);
	        expect(response).to.have.status(200);
			expect(response).to.have.header('content-type', /json/);
		})
		return chakram.wait();
	})
});