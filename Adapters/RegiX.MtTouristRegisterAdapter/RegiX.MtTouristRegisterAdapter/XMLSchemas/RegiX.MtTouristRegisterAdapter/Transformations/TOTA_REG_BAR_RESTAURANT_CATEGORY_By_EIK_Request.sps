<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/MT/BarRestaurantCategoryByEIKRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.MtTouristRegisterAdapter\XMLSchemas\TOTA_REG_BAR_RESTAURANT_CATEGORY_By_EIK_Request.xsd" workingxmlfile="TOTA_REG_BAR_RESTAURANT_CATEGORY_By_EIK_Request.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:BarRestaurantCategoryByEIKRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h5">										<children>											<text fixtext="Входни параметри на справка по ЕИК/БУЛСТАТ за категоризация на заведения за хранене и развлечение"/>										</children>									</paragraph>									<table>										<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>										<children>											<tablebody>												<children>													<tablerow>														<children>															<tablecell>																<properties width="187"/>																<children>																	<text fixtext="ЕИК/БУЛСТАТ:">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:EIK" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<text fixtext=" ">																				<styles font-style="italic"/>																			</text>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>												</children>											</tablebody>										</children>									</table>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>