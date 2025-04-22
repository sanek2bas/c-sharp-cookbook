import clr, sys

sys.path.append(r"D:\develop\c sharp cookbook\Implementing_Dynamic_And_Reflection\Calling.C.Sharp.Code.From.Python\bin\Debug\net9.0")
clr.AddReference(r"D:\develop\c sharp cookbook\Implementing_Dynamic_And_Reflection\Calling.C.Sharp.Code.From.Python\bin\Debug\net9.0\Calling.C.Sharp.Code.From.Python.dll")

from Calling.C.Sharp.Code.From.Python import Report
from Calling.C.Sharp.Code.From.Python import InventoryItem
from System import Decimal

inventory = [
    InventoryItem("1", "Part #1", 3, Decimal(5.26)),
    InventoryItem("2", "Part #2", 1, Decimal(7.95)),
    InventoryItem("3", "Part #1", 2, Decimal(23.13))]

rpt = Report()

result = rpt.GenerateDynamic(inventory)

print(result)
