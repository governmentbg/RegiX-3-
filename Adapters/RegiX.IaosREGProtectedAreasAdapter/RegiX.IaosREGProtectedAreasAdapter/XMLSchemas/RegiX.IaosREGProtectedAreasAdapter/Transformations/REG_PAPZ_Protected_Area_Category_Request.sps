<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/IAOS/REGPapz/ProtectedAreaCategoryRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\src\eGov\RegiX\RegiX.IaosREGProtectedAreasAdapter\XMLSchemas\REG_PAPZ_Protected_Area_Category_Request.xsd" workingxmlfile="REG_PAPZ_Protected_Area_Category_Request.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Заявка за изготвяне на справка по категория на защитена територия/зона в Регистър на защитените територии и зони в България."/>								</children>							</paragraph>							<newline/>							<table>								<properties align="center" border="0" width="100%"/>								<styles width="50%"/>								<children>									<tablebody>										<children>											<tablerow>												<children>													<tablecell>														<children>															<text fixtext="Тип на територията">																<styles font-weight="bold"/>															</text>														</children>													</tablecell>													<tablecell>														<children>															<template match="n1:REG_PAPZ_Protected_Area_Category_Request" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:AreaType" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content/>																		</children>																	</template>																</children>															</template>														</children>													</tablecell>												</children>											</tablerow>											<tablerow>												<children>													<tablecell>														<children>															<text fixtext="Категория на защитената територия">																<styles font-weight="bold"/>															</text>														</children>													</tablecell>													<tablecell>														<children>															<template match="n1:REG_PAPZ_Protected_Area_Category_Request" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:CategoryName" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content/>																		</children>																	</template>																</children>															</template>														</children>													</tablecell>												</children>											</tablerow>										</children>									</tablebody>								</children>							</table>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>