using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DakkaCodeGen.CodeGen;
using DakkaCodeGen.Model;

namespace DakkaCodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            string CurrentDirectory = System.Environment.CurrentDirectory;

            DTO shiftPointDTO = new DTO();
            shiftPointDTO.Code = "ShiftPoint";
            shiftPointDTO.Name = "ShiftPoint";
            shiftPointDTO.HasSub = false;
            shiftPointDTO.Add(new Property("IndexNumber", "IndexNumber", ValidateType.None));
            shiftPointDTO.Add(new Property("Name", "Name", ValidateType.NotNull));
            shiftPointDTO.Add(new Property("PointTime", "PointTime", ValidateType.NotNull));
            shiftPointDTO.Add(new Property("PointType", "PointType", ValidateType.NotNull));
            shiftPointDTO.Add(new Property("Description", "Description", ValidateType.None));

            Entity shiftPoint = new Entity();
            shiftPoint.Code = "ShiftPoint";
            shiftPoint.Name = "ShiftPoint";
            shiftPoint.HasSub = false;
            shiftPoint.DefaultDTO = shiftPointDTO;
            shiftPoint.Add(new Property("IndexNumber", "IndexNumber", ValidateType.None));
            shiftPoint.Add(new Property("Name", "Name", ValidateType.NotNull));
            shiftPoint.Add(new Property("PointTime", "PointTime", ValidateType.NotNull));
            shiftPoint.Add(new Property("PointType", "PointType", ValidateType.NotNull));
            shiftPoint.Add(new Property("Description", "Description", ValidateType.None));

            DTO shiftDto = new DTO();
            shiftDto.Code = "Shift";
            shiftDto.Name = "Shift";
            shiftDto.Add(new Property("Code", "Code", ValidateType.NotNull));
            shiftDto.Add(new Property("Name", "Name", ValidateType.NotNull));
            shiftDto.Add(new Property("Description", "Description", ValidateType.None));
            shiftDto.Add(new Property("ShiftType", "ShiftType", ValidateType.NotNull));
            shiftDto.HasSub = true;
            shiftDto.SubDTO = shiftPointDTO;

            Entity shift = new Entity();
            shift.Code = "Shift";
            shift.Name = "Shift";
            shift.Add(new Property("Code", "Code", ValidateType.NotNull));
            shift.Add(new Property("Name", "Name", ValidateType.NotNull));
            shift.Add(new Property("Description", "Description", ValidateType.None));
            shift.Add(new Property("ShiftType", "ShiftType", ValidateType.NotNull));
            shift.HasSub = true;
            shift.DefaultDTO = shiftDto;
            shift.SubEntity = shiftPoint;

            ControllerCodeGen codeGen = new ControllerCodeGen();
            codeGen.Path = CurrentDirectory;
            codeGen.MainEntity = shift;
            codeGen.CodeGen();
        }
    }
}
